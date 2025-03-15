using AnecdoticaAPI.Models;

namespace AnecdoticaAPI.Requests;

/// <summary>
/// Запрос на получение анекдотов Lvl.2
/// </summary>
public class GetRandItemPRequest : GetAnecdoteRequestBase
{
    /// <summary>
    /// флаг «white_list»  default On
    /// </summary>
    public WhiteListType WhiteListType { get; set; } = WhiteListType.On;

    /// <summary>
    /// флаг цензурирования default On
    /// </summary>
    public CensorType CensorType { get; set; } = CensorType.On;
}