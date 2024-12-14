using Newtonsoft.Json;

public class ServerJarVersionResponse
{
    [JsonProperty("response")]
    public List<ServerJar> Response { get; set; }
}

public class ServerJar
{
    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("file")]
    public string File { get; set; }
}