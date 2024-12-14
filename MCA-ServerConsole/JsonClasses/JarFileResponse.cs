using Newtonsoft.Json;

public class JarFileResponse
{
    [JsonProperty("response")]
    public JarResponse Response { get; set; }
}

public class JarResponse
{
    [JsonProperty("url")]
    public string Url { get; set; }
}