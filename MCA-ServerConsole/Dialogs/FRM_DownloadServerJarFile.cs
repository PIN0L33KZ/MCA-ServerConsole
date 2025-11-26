using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.Linq;

namespace MCA_ServerConsole.Properties
{
    public partial class FRM_DownloadServerJarFile : Form
    {
        private readonly List<string> CachedServerTypes = [];
        private readonly Dictionary<string, List<string>> CachedServerVersions = [];

        // Cached Piston manifest + quick lookup by version id
        private VersionManifest? _versionManifest;
        private readonly Dictionary<string, MinecraftVersionInfo> _versionById =
            new(StringComparer.OrdinalIgnoreCase);
        private readonly string? _initialServerPath;

        public FRM_DownloadServerJarFile(string storagePath)
        {
            InitializeComponent();
            _initialServerPath = storagePath;
        }

        private async void FRM_DownloadServerJarFile_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // Clear comboboxes and disable version selection
                    CBX_ServerType.Items.Clear();
                    CBX_ServerVersion.Items.Clear();
                    CBX_ServerVersion.Enabled = false;

                    // Add placeholder item
                    _ = CBX_ServerType.Items.Add("");
                    CBX_ServerType.SelectedIndex = 0;

                    // Fetch server types (Piston version "types": release, snapshot, etc.)
                    await FetchAndPopulateServerTypes(CBX_ServerType);

                    // Fetch matching versions
                    string? selectedType = CBX_ServerType.SelectedItem?.ToString();
                    if(!string.IsNullOrEmpty(selectedType))
                    {
                        await FetchAndPopulateVersions(selectedType, CBX_ServerVersion);
                        CBX_ServerVersion.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(PingException ex)
            {
                _ = MessageBox.Show(this, "Ping failed: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(HttpRequestException ex)
            {
                _ = MessageBox.Show(this, "Failed to fetch server versions: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(TaskCanceledException)
            {
                _ = MessageBox.Show(this, "The request timed out. Please try again.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CBX_ServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // Fetch matching versions
                    string? selectedType = CBX_ServerType.SelectedItem?.ToString();
                    if(!string.IsNullOrEmpty(selectedType))
                    {
                        await FetchAndPopulateVersions(selectedType, CBX_ServerVersion);
                        CBX_ServerVersion.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(PingException ex)
            {
                _ = MessageBox.Show(this, "Ping failed: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(HttpRequestException ex)
            {
                _ = MessageBox.Show(this, "Failed to fetch server versions: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(TaskCanceledException)
            {
                _ = MessageBox.Show(this, "The request timed out. Please try again.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ensure the Piston version manifest is downloaded and cached.
        /// </summary>
        private async Task EnsureVersionManifestLoaded()
        {
            if(_versionManifest != null)
            {
                return;
            }

            string manifestUrl = "https://piston-meta.mojang.com/mc/game/version_manifest_v2.json";

            using HttpClient httpClient = new();
            string json = await httpClient.GetStringAsync(manifestUrl);

            VersionManifest? manifest = JsonConvert.DeserializeObject<VersionManifest>(json);
            _versionManifest = manifest ?? throw new Exception("Version manifest response was empty.");

            _versionById.Clear();
            foreach(MinecraftVersionInfo version in _versionManifest.Versions)
            {
                if(!_versionById.ContainsKey(version.Id))
                {
                    _versionById[version.Id] = version;
                }
            }
        }

        private async Task FetchAndPopulateServerTypes(ComboBox comboBox)
        {
            // Check cached server types
            if(CachedServerTypes.Count > 0)
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. CachedServerTypes]);
                if(comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }

                return;
            }

            // Check internet connection
            using(Ping ping = new())
            {
                PingReply pingReply = ping.Send("google.de");
                if(pingReply == null || pingReply.Status != IPStatus.Success)
                {
                    _ = MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // Load Piston version manifest
                await EnsureVersionManifestLoaded();

                if(_versionManifest == null)
                {
                    throw new Exception("Version manifest is not available.");
                }

                // Derive distinct version types (release, snapshot, old_beta, old_alpha)
                List<string> types = _versionManifest.Versions
                    .Select(v => v.Type)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(t => t)
                    .ToList();

                CachedServerTypes.AddRange(types);

                // Populate comboBox
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. CachedServerTypes]);

                // Set first item as selected if available
                if(comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch(HttpRequestException ex)
            {
                _ = MessageBox.Show(this, "Failed to fetch server types from Piston API: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task FetchAndPopulateVersions(string category, ComboBox comboBox)
        {
            // Check cached versions for the category (type)
            if(CachedServerVersions.TryGetValue(category, out List<string>? value))
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. value]);
                if(comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }

                return;
            }

            // Check internet connection
            using(Ping ping = new())
            {
                PingReply pingReply = ping.Send("google.de");
                if(pingReply == null || pingReply.Status != IPStatus.Success)
                {
                    _ = MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // Ensure manifest loaded
                await EnsureVersionManifestLoaded();

                if(_versionManifest == null)
                {
                    throw new Exception("Version manifest is not available.");
                }

                // Filter versions by type (category)
                List<string> versions = _versionManifest.Versions
                    .Where(v => string.Equals(v.Type, category, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(v => v.ReleaseTime)
                    .Select(v => v.Id)
                    .ToList();

                CachedServerVersions[category] = versions;

                // Populate comboBox
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. versions]);

                // Set first item as selected if available
                if(comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error fetching server versions from Piston API: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTN_DownloadServerJarFile_Click(object sender, EventArgs e)
        {
            // Check internet connection
            using Ping ping = new();
            PingReply pingReply = ping.Send("google.de");
            if(pingReply == null || pingReply.Status != IPStatus.Success)
            {
                _ = MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected type and version
            string? selectedType = CBX_ServerType.SelectedItem?.ToString();
            string? selectedVersion = CBX_ServerVersion.SelectedItem?.ToString();

            if(string.IsNullOrWhiteSpace(selectedType) || string.IsNullOrWhiteSpace(selectedVersion))
            {
                _ = MessageBox.Show(this, "Please select a valid server type and version.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CBX_ServerType.Enabled = false;
                CBX_ServerVersion.Enabled = false;
                BTN_DownloadServerJarFile.Enabled = false;

                // Download the official Mojang server jar
                await DownloadJarFile(selectedType, selectedVersion, _initialServerPath, PGB_Download);

                this.Close();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DownloadJarFile(string type, string version, string saveDirectory, ProgressBar progressBar)
        {
            // type is now the Piston "version type" (release/snapshot/etc.) but not needed for the actual download.
            progressBar.Invoke(new Action(progressBar.Show));

            try
            {
                // Ensure manifest loaded
                await EnsureVersionManifestLoaded();

                if(_versionManifest == null)
                {
                    throw new Exception("Version manifest is not available.");
                }

                if(!_versionById.TryGetValue(version, out MinecraftVersionInfo? versionInfo))
                {
                    // Fallback in case dictionary is out of sync
                    versionInfo = _versionManifest.Versions
                        .FirstOrDefault(v => v.Id.Equals(version, StringComparison.OrdinalIgnoreCase));
                }

                if(versionInfo == null)
                {
                    _ = MessageBox.Show(this, $"The selected version '{version}' could not be found in the Piston manifest.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using HttpClient httpClient = new();
                httpClient.Timeout = TimeSpan.FromSeconds(20);

                // Fetch the version detail JSON from its URL
                string versionJson = await httpClient.GetStringAsync(versionInfo.Url);
                VersionDetail? versionDetail = JsonConvert.DeserializeObject<VersionDetail>(versionJson);

                string? downloadUrl = versionDetail?.Downloads?.Server?.Url;
                if(string.IsNullOrWhiteSpace(downloadUrl))
                {
                    _ = MessageBox.Show(this,
                        "This version does not provide a dedicated server download (downloads.server.url is missing).",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create save directory if it does not exist
                if(!Directory.Exists(saveDirectory))
                {
                    _ = Directory.CreateDirectory(saveDirectory);
                }

                // Determine file name and download path
                string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
                string downloadPath = Path.Combine(saveDirectory, fileName);

                // Download the .jar file with progress
                using(HttpResponseMessage fileResponse = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    _ = fileResponse.EnsureSuccessStatusCode(); // Throws if the status code is not 2xx

                    long? contentLength = fileResponse.Content.Headers.ContentLength;

                    if(contentLength == null)
                    {
                        _ = MessageBox.Show(this, "Failed to retrieve file size. Cannot show progress.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Set up progress bar
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;
                    progressBar.Value = 0;

                    using FileStream fileStream = new(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    using Stream contentStream = await fileResponse.Content.ReadAsStreamAsync();
                    byte[] buffer = new byte[8192]; // 8 KB buffer size
                    long totalBytesRead = 0;
                    int bytesRead;

                    while((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                    {
                        await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                        totalBytesRead += bytesRead;

                        // Update progress bar
                        int progress = (int)(totalBytesRead * 100 / contentLength.Value);
                        progressBar.Invoke(new Action(() => progressBar.Value = progress));
                    }
                }

                _ = MessageBox.Show(this, $"Download completed! File saved to: {downloadPath}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(HttpRequestException ex)
            {
                _ = MessageBox.Show(this, "Failed to download the .jar file: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IOException ex)
            {
                _ = MessageBox.Show(this, "Error saving the .jar file: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset progress bar when done
                progressBar.Invoke(new Action(progressBar.Hide));
            }
        }

    }
}