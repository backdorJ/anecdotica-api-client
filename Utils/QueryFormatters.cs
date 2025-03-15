using AnecdoticaAPI.Models;

namespace AnecdoticaAPI.Utils;

public static class QueryFormatters
{
    /// <summary>
    /// Получить нужный формат метода для запроса
    /// </summary>
    /// <param name="apiMethodType">Метод</param>
    /// <returns>Корректный метод</returns>
    public static string GetCorrectFormatString(ApiMethodType apiMethodType)
        => apiMethodType switch
        {
            ApiMethodType.GetRandItem => "getRandItem",
            ApiMethodType.GetRandItemP => "getRandItemP",
            ApiMethodType.GetRandItemT => "getRandItemT",
            _ => throw new ArgumentOutOfRangeException(nameof(apiMethodType), apiMethodType, null)
        };

    /// <summary>
    /// Получить нужную кодировку в виде строки
    /// </summary>
    /// <param name="charsetType">Кодировка</param>
    /// <returns>Кодировка</returns>
    public static string GetCorrectFormatCharset(CharsetType charsetType)
        => charsetType switch
        {
            CharsetType.Utf8 => "utf-8",
            CharsetType.Cp1251 => "cp1251",
            CharsetType.Koi8R => "koi8-r",
            _ => throw new ArgumentOutOfRangeException(nameof(charsetType), charsetType, null)
        };
}