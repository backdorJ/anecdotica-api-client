using AnecdoticaAPI.Configurations;
using AnecdoticaAPI.Models;
using AnecdoticaAPI.Requests;
using AnecdoticaAPI.Urls;
using AnecdoticaAPI.Utils;
using Newtonsoft.Json;

namespace AnecdoticaAPI;

public class AnecdoticaApiClient
{
    private readonly AnecdoticaApiConfig _config = new();
    private readonly HttpClient _httpClient;

    public AnecdoticaApiClient(Action<AnecdoticaApiConfig> config)
    {
        config.Invoke(_config);
        
        if (_config.SendType == SendType.ByToken && string.IsNullOrWhiteSpace(_config.Token))
            throw new ArgumentNullException(nameof(_config.Token), "Введите токен, который вам выдали на сайте");

        if (_config.SendType == SendType.ByHash && string.IsNullOrWhiteSpace(_config.SecureKey))
            throw new ArgumentNullException(nameof(_config.SecureKey), "Введите секретный ключ");
        
        if (string.IsNullOrWhiteSpace(_config.Pid))
            throw new ArgumentNullException(nameof(_config.Pid), "Введите pid вашего профиля");
        
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrls.BaseAddressForApi);
    }

    /// <summary>
    /// Получение случайного анекдота из «белого списка» с возможностью выбора категории, страны, языка, серии и жанра в заданном формате и кодировке.
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Результат</returns>
    public async Task<ApiResponse> GetRandItemAsync(GetRandItemRequest request)
        => await GetResponseAsync(request, ApiMethodType.GetRandItem);

    /// <summary>
    /// Получение случайного анекдота с возможностью выбора категории, жанра, серии, страны, языка, списка и тега в заданном формате и кодировке.
    /// </summary>
    /// <returns>Результат</returns>
    public async Task<ApiResponse> GetRandItemPAsync(GetRandItemPRequest request)
    {
        if (_config.ApiLevel == ApiLevel.Lvl1)
            throw new ArgumentException("Данный метод доступен при наличии LvlApi >= 2");
        
        return await GetResponseAsync(request, ApiMethodType.GetRandItemP);
    }

    /// <summary>
    /// Получение списка анекдотов по тегу с возможностью выбора категории, языка и жанра в заданном формате и кодировке.
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Результат</returns>
    public async Task<ApiResponse> GetRandItemTAsync(GetRandItemPRequest request)
    {
        if (_config.ApiLevel is ApiLevel.Lvl1 or ApiLevel.Lvl2)
            throw new ArgumentException("Данный метод доступен при наличии LvlApi > 2");
        
        
        return await GetResponseAsync(request, ApiMethodType.GetRandItemT);
    }

    /// <summary>
    /// Получение списка анекдотов по тегу с возможностью выбора категории, языка и жанра в заданном формате и кодировке.
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Результат</returns>
    public async Task<ApiResponse> GetItemsAsync(GetItemsRequest request)
    {
        if (_config.ApiLevel != ApiLevel.Lvl4)
            throw new ArgumentException("Данный метод доступен при наличии LvlApi > 3");
        
        return await GetResponseAsync(request, ApiMethodType.GetItems);
    }

    private async Task<ApiResponse> GetResponseAsync(GetAnecdoteRequestBase request, ApiMethodType apiMethodType)
    {
        var url = $"{BaseUrls.BaseAddressForApi}{QueryBuilder.GetQueryForApi(
            (_config.SendType == SendType.ByToken ? _config.Token : _config.SecureKey)!,
            _config.Pid,
            request,
            apiMethodType,
            _config.SendType)}";
        
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
        var content = await response.Content.ReadAsStringAsync();

        return request.ResponseFormat switch
        {
            ResponseFormat.Json => new ApiResponse()
            {
                ResponseFormat = ResponseFormat.Json,
                JsonResponse = JsonConvert.DeserializeObject<JsonResponse>(content)!,
            },
            ResponseFormat.Html or ResponseFormat.Txt or ResponseFormat.Xml => new ApiResponse
            {
                ResponseFormat = request.ResponseFormat,
                StringResponse = new StringResponse()
                {
                    Response = content
                }
            },
            _ => throw new InvalidDataException("Неизвестный формат")
        };
    }
}