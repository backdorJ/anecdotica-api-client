﻿namespace AnecdoticaAPI.Models;

public enum ApiMethodType
{
    /// <summary>
    /// Получение случайного анекдота из «белого списка» с возможностью выбора категории, страны, языка, серии и жанра в заданном формате и кодировке.
    /// </summary>
    GetRandItem = 1,
    
    /// <summary>
    /// Получение случайного анекдота с возможностью выбора категории, жанра, серии, страны, языка, списка и тега в заданном формате и кодировке.
    /// </summary>
    GetRandItemP = 2, 
    
    /// <summary>
    /// Получение случайного анекдота с возможностью выбора по одному или нескольким тегам (без указания их id), категории, жанру, серии, стране, языку и списку в заданном формате и кодировке.
    /// </summary>
    GetRandItemT  = 3,
    
    /// <summary>
    /// Получение списка анекдотов по тегу с возможностью выбора категории, языка и жанра в заданном формате и кодировке.
    /// </summary>
    GetItems = 4, 
}