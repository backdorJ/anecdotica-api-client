namespace AnecdoticaAPI.Models;

public enum ApiLevel
{
    /// <summary>
    /// Lvl 1. Доступен только метод getRandItem 
    /// </summary>
    Lvl1 = 1,
    
    /// <summary>
    /// Lvl 2. Доступны методы getRandItem, getRandItemP и параметры с цензурой censor, wlist
    /// </summary>
    Lvl2 = 2,
    
    /// <summary>
    /// Lvl 3. Доступны методы getRandItem, getRandItemP, getRandItemT
    /// </summary>
    Lvl3 = 3,
    
    /// <summary>
    /// Lvl 4. Доступны методы getRandItem, getRandItemP, getRandItemT, getItems 
    /// </summary>
    Lvl4 = 4,
}