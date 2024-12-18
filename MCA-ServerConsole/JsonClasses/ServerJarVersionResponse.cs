using Newtonsoft.Json;

public class ServerJarVersionResponse
{
    [JsonProperty("response")]
    public required List<ServerJar> Response { get; set; }
}

public class ServerJar
{
    [JsonProperty("version")]
    public required string Version { get; set; }

    [JsonProperty("file")]
    public required string File { get; set; }
}