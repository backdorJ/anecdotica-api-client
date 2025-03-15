namespace AnecdoticaAPI.Models;

/// <summary>
/// Жанр
/// </summary>
public enum GenreType
{
    /// <summary>
    /// Все жанры.
    /// </summary>
    All = 0,

    /// <summary>
    /// Анекдоты.
    /// </summary>
    Anecdotes = 1,

    /// <summary>
    /// Анекдоты-загадки.
    /// </summary>
    RiddleAnecdotes = 2,

    /// <summary>
    /// Афоризмы.
    /// </summary>
    Aphorisms = 3,

    /// <summary>
    /// Микро анекдоты.
    /// </summary>
    MicroAnecdotes = 4,

    /// <summary>
    /// Пословицы и поговорки.
    /// </summary>
    Proverbs = 5,

    /// <summary>
    /// Ляпы, очепятки и пёрлы.
    /// </summary>
    Bloopers = 6
}