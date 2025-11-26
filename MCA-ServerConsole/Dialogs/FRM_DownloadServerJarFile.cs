using MCA_ServerConsole.HelperClasses;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace MCA_ServerConsole.Properties
{
    public partial class FRM_DownloadServerJarFile : Form
    {
        private VersionManifest? _versionManifest;

        private readonly List<string> CachedServerTypes = new();
        private readonly Dictionary<string, List<string>> CachedServerVersions = new();
        private readonly Dictionary<string, long> _serverJarSizeCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, string> _serverJarUrlCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, MinecraftVersionInfo> _versionById =
            new(StringComparer.OrdinalIgnoreCase);

        private readonly string? _initialServerPath;

        public FRM_DownloadServerJarFile(string storagePath)
        {
            InitializeComponent();
            _initialServerPath = storagePath;
        }

        private void SetBusy(bool isBusy)
        {
            UseWaitCursor = isBusy;
            CBX_ServerType.Enabled = !isBusy;
            CBX_ServerVersion.Enabled = !isBusy;
            BTN_DownloadServerJarFile.Enabled = !isBusy;
        }

        private async void FRM_DownloadServerJarFile_Load(object sender, EventArgs e)
        {
            SetBusy(true);
            await LoadManifestAndServerTypes();
        }

        private async Task LoadManifestAndServerTypes()
        {
            if(_versionManifest != null)
            {
                LoadServerTypesIntoCombo();
                return;
            }

            using Ping ping = new();
            if(ping.Send("google.de")?.Status != IPStatus.Success)
            {
                MessageBox.Show(this, "No internet connection detected.",
                    "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url = "https://piston-meta.mojang.com/mc/game/version_manifest_v2.json";

            using HttpClient client = new();
            string json = await client.GetStringAsync(url);

            _versionManifest = JsonConvert.DeserializeObject<VersionManifest>(json)
                ?? throw new Exception("Manifest empty");

            _versionById.Clear();
            foreach(var v in _versionManifest.Versions)
                _versionById[v.Id] = v;

            LoadServerTypesIntoCombo();
        }

        private void LoadServerTypesIntoCombo()
        {
            if(CachedServerTypes.Count == 0)
            {
                // Collect distinct server types
                CachedServerTypes.AddRange(
                    _versionManifest!.Versions
                    .Select(v => v.Type)
                    .Where(t => !t.Equals("old_alpha", StringComparison.OrdinalIgnoreCase)
                        && !t.Equals("old_beta", StringComparison.OrdinalIgnoreCase))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(a => a)
                );
            }

            CBX_ServerType.Items.Clear();
            CBX_ServerType.Items.AddRange(CachedServerTypes.Cast<object>().ToArray());
            if(CBX_ServerType.Items.Count > 0)
                CBX_ServerType.SelectedIndex = 0;
        }

        private async void CBX_ServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBusy(true);
            try
            {
                string? selectedType = CBX_ServerType.SelectedItem?.ToString();
                if(string.IsNullOrWhiteSpace(selectedType))
                {
                    CBX_ServerVersion.Items.Clear();
                    BTN_DownloadServerJarFile.Text = "Download";
                    return;
                }

                await LoadVersionsForType(selectedType);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async Task LoadVersionsForType(string type)
        {
            if(CachedServerVersions.TryGetValue(type, out var cached))
            {
                CBX_ServerVersion.Items.Clear();
                CBX_ServerVersion.Items.AddRange(cached.Cast<object>().ToArray());
                CBX_ServerVersion.Enabled = true;

                if(cached.Count > 0)
                    CBX_ServerVersion.SelectedIndex = 0;

                return;
            }

            // Filter versions by type
            var versions = _versionManifest!.Versions
                .Where(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(v => v.ReleaseTime)
                .ToList();

            var ids = versions.Select(v => v.Id).ToList();
            CachedServerVersions[type] = ids;

            // Load details (download URL + size)
            await LoadVersionDetailsForVersions(ids);

            CBX_ServerVersion.Items.Clear();
            CBX_ServerVersion.Items.AddRange(ids.Cast<object>().ToArray());
            CBX_ServerVersion.Enabled = true;

            if(ids.Count > 0)
                CBX_ServerVersion.SelectedIndex = 0;
        }

        private async Task LoadVersionDetailsForVersions(List<string> versionIds)
        {
            using HttpClient client = new();

            foreach(string versionId in versionIds)
            {
                if(_serverJarUrlCache.ContainsKey(versionId))
                    continue;

                var versionInfo = _versionById[versionId];

                string json = await client.GetStringAsync(versionInfo.Url);
                var detail = JsonConvert.DeserializeObject<VersionDetail>(json);

                var server = detail?.Downloads.Server;
                if(server == null)
                    continue;

                _serverJarUrlCache[versionId] = server.Url;
                _serverJarSizeCache[versionId] = server.Size;
            }
        }

        private void CBX_ServerVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? version = CBX_ServerVersion.SelectedItem?.ToString();
            if(string.IsNullOrWhiteSpace(version))
            {
                BTN_DownloadServerJarFile.Text = "Download";
                return;
            }

            if(_serverJarSizeCache.TryGetValue(version, out long size))
                BTN_DownloadServerJarFile.Text = $"Download ({JavaHelper.FormatBytes(size)})";
            else
                BTN_DownloadServerJarFile.Text = "Download (size unknown)";
        }

        private async void BTN_DownloadServerJarFile_Click(object sender, EventArgs e)
        {
            SetBusy(true);

            this.Size = new Size(238, 171);

            // Prepare progress bar
            PGB_Download.Visible = true;
            PGB_Download.Minimum = 0;
            PGB_Download.Maximum = 100;
            PGB_Download.Value = 0;
            PGB_Download.Style = ProgressBarStyle.Continuous;

            try
            {
                string? version = CBX_ServerVersion.SelectedItem?.ToString();
                if(string.IsNullOrWhiteSpace(version))
                    return;

                if(!_serverJarUrlCache.TryGetValue(version, out string? url))
                {
                    MessageBox.Show(this, "No cached download URL available.",
                        "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string saveDirectory = _initialServerPath!;
                if(!Directory.Exists(saveDirectory))
                    Directory.CreateDirectory(saveDirectory);

                string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                string path = Path.Combine(saveDirectory, CBX_ServerVersion.SelectedItem == null ? fileName : CBX_ServerVersion.SelectedItem.ToString() + @"_server.jar");

                using HttpClient httpClient = new();
                using var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                long size = response.Content.Headers.ContentLength ??
                            _serverJarSizeCache.GetValueOrDefault(version);

                bool sizeKnown = size > 0;

                // Use Marquee when file size is unknown
                if(!sizeKnown)
                {
                    PGB_Download.Style = ProgressBarStyle.Marquee;
                    PGB_Download.MarqueeAnimationSpeed = 30;
                }

                using Stream input = await response.Content.ReadAsStreamAsync();
                using FileStream output = new(path, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[8192];
                long read = 0;
                int bytes;

                while((bytes = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await output.WriteAsync(buffer, 0, bytes);
                    read += bytes;

                    if(sizeKnown)
                    {
                        // Update progress
                        double percent = (double)read / size * 100.0;
                        int value = (int)Math.Round(percent);
                        value = Math.Clamp(value, PGB_Download.Minimum, PGB_Download.Maximum);

                        PGB_Download.Value = value;
                        PGB_Download.Refresh();
                    }
                }

                if(sizeKnown)
                    PGB_Download.Value = 100;

                MessageBox.Show(this, $"Download complete:\n{path}",
                    "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Hide progress bar
                PGB_Download.Visible = false;
                this.Size = new Size(238, 152);
                SetBusy(false);
            }
        }
    }
}