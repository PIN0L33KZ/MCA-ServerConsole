using Newtonsoft.Json;

/// <summary>
/// Version detail JSON for a single Minecraft version.
/// </summary>
public class VersionDetail
{
    [JsonProperty("downloads")]
    public required VersionDownloads Downloads { get; set; }
}

public class VersionDownloads
{
    // We care mainly about this for dedicated server downloads.
    [JsonProperty("server")]
    public DownloadEntry? Server { get; set; }

    [JsonProperty("server_mappings")]
    public DownloadEntry? ServerMappings { get; set; }

    [JsonProperty("client")]
    public DownloadEntry? Client { get; set; }

    [JsonProperty("client_mappings")]
    public DownloadEntry? ClientMappings { get; set; }
}

public class DownloadEntry
{
    [JsonProperty("sha1")]
    public required string Sha1 { get; set; }

    [JsonProperty("size")]
    public required long Size { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }
}