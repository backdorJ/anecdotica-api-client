using AnecdoticaAPI.Models;

namespace AnecdoticaAPI.Requests;

public class GetAnecdoteResponse
{
    /// <summary>
    /// Формат данных
    /// </summary>
    public ResponseFormat Format { get; set; }

    /// <summary>
    /// Данные
    /// </summary>
    public GetAnecdoteData Data { get; set; }
}