using Newtonsoft.Json;

namespace AnecdoticaAPI.Models;

public class Item
{
    [JsonProperty("text")]
    public string? Text { get; set; }

    [JsonProperty("note")]
    public string? Note { get; set; }
}