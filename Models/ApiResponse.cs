using Newtonsoft.Json;

namespace AnecdoticaAPI.Models;

public class ApiResponse
{
    /// <summary>
    /// Тип ответа
    /// </summary>
    public ResponseFormat ResponseFormat { get; set; }

    /// <summary>
    /// Ответ в виде Json
    /// </summary>
    public JsonResponse? JsonResponse { get; set; }
    
    /// <summary>
    /// Ответ в виде xml, txt, html
    /// </summary>
    public StringResponse? StringResponse { get; set; }
}