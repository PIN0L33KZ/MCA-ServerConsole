﻿using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace MCA_ServerConsole.Properties
{
    public partial class FRM_DownloadServerJarFile : Form
    {
        private readonly List<string> CachedServerTypes = [];
        private readonly Dictionary<string, List<string>> CachedServerVersions = [];

        public FRM_DownloadServerJarFile()
        {
            InitializeComponent();
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
                    CBX_ServerType.Items.Add("");
                    CBX_ServerType.SelectedIndex = 0;

                    // Fetch server types
                    await FetchAndPopulateServerTypes(CBX_ServerType);

                    // Fetch matching versions
                    var selectedType = CBX_ServerType.SelectedItem?.ToString();
                    if(!string.IsNullOrEmpty(selectedType))
                    {
                        await FetchAndPopulateVersions(selectedType, CBX_ServerVersion);
                        CBX_ServerVersion.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(PingException ex)
            {
                // Handle ping-specific exceptions
                MessageBox.Show(this, "Ping failed: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(HttpRequestException ex)
            {
                // Handle HTTP request exceptions
                MessageBox.Show(this, "Failed to fetch server versions: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(TaskCanceledException)
            {
                // Handle request timeouts
                MessageBox.Show(this, "The request timed out. Please try again.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
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
                    var selectedType = CBX_ServerType.SelectedItem?.ToString();
                    if(!string.IsNullOrEmpty(selectedType))
                    {
                        await FetchAndPopulateVersions(selectedType, CBX_ServerVersion);
                        CBX_ServerVersion.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(PingException ex)
            {
                // Handle ping-specific exceptions
                MessageBox.Show(this, "Ping failed: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(HttpRequestException ex)
            {
                // Handle HTTP request exceptions
                MessageBox.Show(this, "Failed to fetch server versions: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(TaskCanceledException)
            {
                // Handle request timeouts
                MessageBox.Show(this, "The request timed out. Please try again.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    comboBox.SelectedIndex = 0;
                return;
            }

            // Check internet connection
            using(var ping = new Ping())
            {
                var pingReply = ping.Send("google.de");
                if(pingReply == null || pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string apiUrl = "https://api.serverjars.in/v1/serverjars/fetchTypes";

            try
            {
                using var httpClient = new HttpClient();
                // Send API request
                var response = await httpClient.GetStringAsync(apiUrl);

                // Deserialize JSON response
                var serverTypesResponse = JsonConvert.DeserializeObject<ServerTypesResponse>(response);

                // Add types to cache
                CachedServerTypes.AddRange(serverTypesResponse.Response.Modded);
                CachedServerTypes.AddRange(serverTypesResponse.Response.Proxies);
                CachedServerTypes.AddRange(serverTypesResponse.Response.Vanilla);
                CachedServerTypes.AddRange(serverTypesResponse.Response.Servers);

                // Populate comboBox
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. CachedServerTypes]);

                // Set first item as selected if available
                if(comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show(this, "Failed to fetch server types: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task FetchAndPopulateVersions(string category, ComboBox comboBox)
        {
            // Check cached versions for the category
            if(CachedServerVersions.TryGetValue(category, out List<string>? value))
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. value]);
                if(comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
                return;
            }

            // Check internet connection
            using(var ping = new Ping())
            {
                var pingReply = ping.Send("google.de");
                if(pingReply == null || pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string apiUrl = $"https://api.serverjars.in/v1/serverjars/fetchAll/{category}";

            try
            {
                using var httpClient = new HttpClient();
                // Send API request
                var response = await httpClient.GetStringAsync(apiUrl);

                // Deserialize JSON response
                var serverJarResponse = JsonConvert.DeserializeObject<ServerJarVersionResponse>(response);

                // Add versions to cache
                var versions = new List<string>();
                foreach(var jar in serverJarResponse.Response)
                {
                    if(jar != null && jar.Version != null) // Null check for jar and jar.Version
                    {
                        versions.Add(jar.Version);
                    }
                }
                CachedServerVersions[category] = versions;

                // Populate comboBox
                comboBox.Items.Clear();
                comboBox.Items.AddRange([.. versions]);

                // Set first item as selected if available
                if(comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error fetching server versions: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTN_DownloadServerJarFile_Click(object sender, EventArgs e)
        {
            // Check internet connection
            using var ping = new Ping();
            var pingReply = ping.Send("google.de");
            if(pingReply == null || pingReply.Status != IPStatus.Success)
            {
                MessageBox.Show(this, "No internet connection detected. Please check your network settings.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Download Jar file
            // Get selected type and version
            var selectedType = CBX_ServerType.SelectedItem?.ToString();
            var selectedVersion = CBX_ServerVersion.SelectedItem?.ToString();

            if(string.IsNullOrWhiteSpace(selectedType) || string.IsNullOrWhiteSpace(selectedVersion))
            {
                MessageBox.Show(this, "Please select a valid server type and version.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Specify the save directory
            try
            {
                // Folder browser dialog configuration
                var fBD = new FolderBrowserDialog()
                {
                    Description = "Select where to store your jar file.",
                    ShowHiddenFiles = false,
                    ShowNewFolderButton = true,
                    SelectedPath = Properties.Settings.Default.ServerDirectory.Length > 0
                        ? Properties.Settings.Default.ServerDirectory + '\\'
                        : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + '\\'
                };

                // User cancels the dialog
                if(fBD.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Validate the selected path
                if(string.IsNullOrWhiteSpace(fBD.SelectedPath) || !Directory.Exists(fBD.SelectedPath))
                {
                    MessageBox.Show(this, "Invalid directory selected. Please try again.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CBX_ServerType.Enabled = false;
                CBX_ServerVersion.Enabled = false;
                BTN_DownloadServerJarFile.Enabled = false;

                // Call the download method
                await DownloadJarFile(selectedType, selectedVersion, fBD.SelectedPath.ToString(), PGB_Download);

                CBX_ServerType.Enabled = true;
                CBX_ServerVersion.Enabled = true;
                BTN_DownloadServerJarFile.Enabled = true;
            }
            catch(Exception ex)
            {
                // Catch unexpected errors and display them
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DownloadJarFile(string type, string version, string saveDirectory, ProgressBar progressBar)
        {
            progressBar.Invoke(new Action(() => progressBar.Show()));

            string apiUrl = $"https://api.serverjars.in/v1/serverjars/fetchJar/{type}/{version}";

            try
            {
                using var httpClient = new HttpClient();

                // Fetch the jar download URL from the API
                var response = await httpClient.GetStringAsync(apiUrl);
                var jarResponse = JsonConvert.DeserializeObject<JarFileResponse>(response);

                // Check if the URL is valid
                if(jarResponse?.Response?.Url == null)
                {
                    MessageBox.Show(this, "Invalid response from the server. Unable to fetch download URL.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string downloadUrl = jarResponse.Response.Url;

                // Create save directory if it doesn't exist
                if(!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                // Determine file name and download path
                string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
                string downloadPath = Path.Combine(saveDirectory, fileName);

                // Download the .jar file with progress
                using(var fileResponse = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    fileResponse.EnsureSuccessStatusCode(); // Throws if the status code is not 2xx

                    var contentLength = fileResponse.Content.Headers.ContentLength;

                    if(contentLength == null)
                    {
                        MessageBox.Show(this, "Failed to retrieve file size. Cannot show progress.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Set up progress bar
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;
                    progressBar.Value = 0;

                    using(var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    using(var contentStream = await fileResponse.Content.ReadAsStreamAsync())
                    {
                        var buffer = new byte[8192]; // 8 KB buffer size
                        long totalBytesRead = 0;
                        int bytesRead;

                        while((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            // Update progress bar
                            int progress = (int)((totalBytesRead * 100) / contentLength.Value);
                            progressBar.Invoke(new Action(() => progressBar.Value = progress));
                        }
                    }
                }

                MessageBox.Show(this, $"Download completed! File saved to: {downloadPath}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show(this, "Failed to download the .jar file: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IOException ex)
            {
                MessageBox.Show(this, "Error saving the .jar file: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset progress bar when done
                progressBar.Invoke(new Action(() => progressBar.Hide()));
            }
        }
    }
}