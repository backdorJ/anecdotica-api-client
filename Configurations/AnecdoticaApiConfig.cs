using AnecdoticaAPI.Models;

namespace AnecdoticaAPI.Configurations;

public class AnecdoticaApiConfig
{
    /// <summary>
    /// ИД профиля
    /// </summary>
    public string Pid { get; set; } = null!;

    /// <summary>
    /// Токен сгенерированный в профиле
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// Тип запроса
    /// </summary>
    public SendType SendType { get; set; } = SendType.ByToken;

    /// <summary>
    /// Секретный ключ длч запроса с помощью SendType.ByHash
    /// </summary>
    public string? SecureKey { get; set; }

    /// <summary>
    /// Lvl api, который приобретен на сайте (default ApiLevel.Lvl1)
    /// </summary>
    public ApiLevel ApiLevel { get; set; } = ApiLevel.Lvl1;
}