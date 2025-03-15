namespace AnecdoticaAPI.Requests;

/// <summary>
/// Запрос на получение анекдотов Lvl.3
/// </summary>
public class GetItemsRequest : GetRandItemPRequest
{
    /// <summary>
    /// Кол-во анекдотов на страницу default 25
    /// </summary>
    public int Ipp { get; set; } = 25;

    /// <summary>
    /// Номер страницы
    /// </summary>
    public int Page { get; set; }
}