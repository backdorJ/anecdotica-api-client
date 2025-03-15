using AnecdoticaAPI.Models;

namespace AnecdoticaAPI.Requests;

public class GetAnecdoteRequestBase
{
    /// <summary>
    /// Категория
    /// </summary>
    public CategoryType CategoryType { get; set; } = CategoryType.All;

    /// <summary>
    /// Жанр    
    /// </summary>
    public GenreType GenreType { get; set; } = GenreType.All;

    /// <summary>
    /// Серия анекдота
    /// </summary>
    public AnecdoteSeries Series { get; set; } = AnecdoteSeries.All;

    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; set; } = Country.All;

    /// <summary>
    /// Язык
    /// </summary>
    public LangType LangType { get; set; } = LangType.Russian;

    /// <summary>
    /// Формат ответа
    /// </summary>
    public ResponseFormat ResponseFormat { get; set; } = ResponseFormat.Json;

    /// <summary>
    /// Кодировка
    /// </summary>
    public CharsetType CharsetType { get; set; } = CharsetType.Utf8;

    /// <summary>
    /// Флаг html-разметки
    /// </summary>
    public MarkupType MarkupType { get; set; } = MarkupType.On;

    /// <summary>
    /// Флаг примечания
    /// </summary>
    public NoteType NoteType { get; set; } = NoteType.On;
}