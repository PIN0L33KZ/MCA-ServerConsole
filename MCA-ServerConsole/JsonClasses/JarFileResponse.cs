using Newtonsoft.Json;

public class JarFileResponse
{
    [JsonProperty("response")]
    public required JarResponse Response { get; set; }
}

public class JarResponse
{
    [JsonProperty("url")]
    public required string Url { get; set; }
}