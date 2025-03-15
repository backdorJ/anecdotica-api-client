using Newtonsoft.Json;

namespace AnecdoticaAPI.Models;

public class Result
{
    [JsonProperty("error")]
    public string? Error { get; set; }

    [JsonProperty("errMsg")]
    public string? ErrorMessage { get; set; }
}