## 📖 Описание

**AnecdoticaAPI** — это .NET-клиент для работы с API анекдотов, который берет данные с api http://anecdotica.ru/offer/api.html#3.1. Он упрощает взаимодействие с сервисом, предоставляя удобные методы для получения случайных анекдотов, поиска по категории, фильтруя по цензурности, белого, черного листа.

---

## 🚀 Установка

```sh 

dotnet add package anecdotica-api-client
```

## 🌠 Использование

### Инициализация клиента

```csharp

using AnecdoticaAPI;
using AnecdoticaAPI.Models;
using AnecdoticaAPI.Requests;

var client = new AnecdoticaApiClient(config =>
{
    config.Pid = "pid который вам выдали на сайте API";
    config.Token = "Если предпочтете использовать токен в запросах";
    config.SecureKey = "Секретный ключ так же выдается на сайте API, дугой метод аутентификации более безопасный";
    config.SendType = SendType.ByHash; // ByHash - аутентификация происходит с помощью хеша более безопасно
                                      // ByToken - аутентификация на основе токена
    config.ApiLevel = ApiLevel.Lvl1;
        // ApiLevel.Lvl1
        // ApiLevel.Lvl2
        // ApiLevel.Lvl3
        // ApiLevel.Lvl4 - Lvl приобретается на сайте API относительно Lvl api будет доступно больше функций
});
```

### Вызов метода

```csharp
var response = await client.GetItemsAsync(new GetItemsRequest
{
    CategoryType = CategoryType.All, // Категория анекдотов
    GenreType = GenreType.All, // Жанр анекдота
    Series = AnecdoteSeries.All, // Серия анекдота, т.е из какой стихии Армянское радио,Винни-Пух и все-все-все. и т.д
    Country = Country.All, // Страна
    LangType = (LangType)0, // Язык анекдотов
    ResponseFormat = (ResponseFormat)0, // В каком формате будет ответ json, xml, txt, html
    CharsetType = (CharsetType)0, // Кодировка
    MarkupType = MarkupType.Off, // Флаг html-разметки
    NoteType = NoteType.Off, // Флаг примечания
    WhiteListType = WhiteListType.Off, // Будут ли анекдоты из white-list
    CensorType = CensorType.Off, // Цензурность
    Ipp = 0, // Кол-во анекдотов на страницу
    Page = 0 // Номер страницы
});
```
### Результат ответа

```csharp

var response = await client.GetRandItemAsync(new GetRandItemRequest
{
   ResponseFormat = ResponseFormat.Xml,
});

Console.WriteLine(response.ResponseFormat); // ResponseFormat.Xml
Console.WriteLine(response.JsonResponse); // null
Console.WriteLine(response.StringResponse); // Xml строка

```
#### К каждому методу и запросу написана xml документация

![img.png](img.png)

## 📝 Контакты 
#### Если у тебя есть вопросы, пиши:
📧 Email: cdbacjdorz@yandex.ru\
🐙 Telegram: https://t.me/daammirka

## 📌 Официальная документация
#### По [ссылке](http://anecdotica.ru/offer/api.html#3.1) вы можете ознакомиться с ценами и документацией API