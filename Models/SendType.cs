namespace AnecdoticaAPI.Models;

public enum SendType
{
    /// <summary>
    /// Отправка запросов с помощью токена
    /// </summary>
    ByToken = 1,
    
    /// <summary>
    /// Отправка запросов с помощью цифровой подписи (более безопасно)
    /// </summary>
    ByHash = 2
}