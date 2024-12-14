using Newtonsoft.Json;

public class ServerTypesResponse
{
    [JsonProperty("response")]
    public ServerTypeCategories Response { get; set; }
}

public class ServerTypeCategories
{
    [JsonProperty("modded")]
    public List<string> Modded { get; set; }

    [JsonProperty("proxies")]
    public List<string> Proxies { get; set; }

    [JsonProperty("vanilla")]
    public List<string> Vanilla { get; set; }

    [JsonProperty("servers")]
    public List<string> Servers { get; set; }
}