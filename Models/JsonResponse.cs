using Newtonsoft.Json;

namespace AnecdoticaAPI.Models;

public class JsonResponse : BaseResponse
{
    [JsonProperty("result")]
    public Result ErrorResult { get; set; } = null!;

    [JsonProperty("item")]
    public Item SuccessItem { get; set; } = null!;
}

public class BaseResponse
{
}