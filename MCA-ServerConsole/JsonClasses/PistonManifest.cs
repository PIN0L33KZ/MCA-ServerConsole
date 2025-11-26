using Newtonsoft.Json;

/// <summary>
/// Represents the top-level Piston version manifest:
/// https://piston-meta.mojang.com/mc/game/version_manifest_v2.json
/// </summary>
public class VersionManifest
{
    [JsonProperty("latest")]
    public required LatestVersionInfo Latest { get; set; }

    [JsonProperty("versions")]
    public required List<MinecraftVersionInfo> Versions { get; set; }
}

public class LatestVersionInfo
{
    [JsonProperty("release")]
    public required string Release { get; set; }

    [JsonProperty("snapshot")]
    public required string Snapshot { get; set; }
}

/// <summary>
/// Single Minecraft version entry in the manifest.
/// This contains NO filesize information.
/// </summary>
public class MinecraftVersionInfo
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("type")]
    public required string Type { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }

    [JsonProperty("time")]
    public required DateTime Time { get; set; }

    [JsonProperty("releaseTime")]
    public required DateTime ReleaseTime { get; set; }

    [JsonProperty("sha1")]
    public required string Sha1 { get; set; }

    [JsonProperty("complianceLevel")]
    public required int ComplianceLevel { get; set; }
}