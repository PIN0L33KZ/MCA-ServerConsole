using Newtonsoft.Json;

public class ServerTypesResponse
{
    [JsonProperty("response")]
    public required ServerTypeCategories Response { get; set; }
}

public class ServerTypeCategories
{
    [JsonProperty("modded")]
    public required List<string> Modded { get; set; }

    [JsonProperty("proxies")]
    public required List<string> Proxies { get; set; }

    [JsonProperty("vanilla")]
    public required List<string> Vanilla { get; set; }

    [JsonProperty("servers")]
    public required List<string> Servers { get; set; }
}