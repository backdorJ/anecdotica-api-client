using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using AnecdoticaAPI.Models;
using AnecdoticaAPI.Requests;
using AnecdoticaAPI.Urls;

namespace AnecdoticaAPI.Utils;

public static class QueryBuilder
{
    public static string GetQueryForApi(
        string key,
        string pid,
        GetAnecdoteRequestBase requestBase,
        ApiMethodType apiMethodType,
        SendType sendType = SendType.ByToken)
    {
        var method = QueryFormatters.GetCorrectFormatString(apiMethodType);

        var builder = new UriBuilder(BaseUrls.BaseAddressForApi);
        var query = HttpUtility.ParseQueryString(builder.Query);
        
        if (sendType == SendType.ByToken)
            query["token"] = key;
        
        query["method"] = method;
        query["pid"] = pid;

        var buildQueryForMethodGetRandItem = apiMethodType switch
        {
            ApiMethodType.GetRandItem => BuildBaseQuery(requestBase, query),
            ApiMethodType.GetRandItemP or ApiMethodType.GetRandItemT => BuildGetRandomItemPQuery((GetRandItemPRequest)requestBase, query),
            ApiMethodType.GetItems => BuildGetItemsQuery((GetItemsRequest) requestBase, query),
            _ => throw new InvalidEnumArgumentException(
                "Неизвестный метод, на данный момент есть только, GetRandItem, GetRandItemP, GetRandItemT")
        };

        if (sendType == SendType.ByHash)
        {   
            DateTime currentTime = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
            buildQueryForMethodGetRandItem["uts"] = unixTime.ToString();
            var signature = MD5Code.GetMD5Hash(buildQueryForMethodGetRandItem + key);

            buildQueryForMethodGetRandItem["hash"] = signature;
        }

        return buildQueryForMethodGetRandItem.ToString()!;
    }

    private static NameValueCollection BuildGetItemsQuery(GetItemsRequest request, NameValueCollection query)
    {
        BuildGetRandomItemPQuery(request, query);
        
        query["ipp"] = request.Ipp.ToString();
        query["page"] = request.Page.ToString();
        
        return query;
    }

    private static NameValueCollection BuildGetRandomItemPQuery(GetRandItemPRequest request, NameValueCollection query)
    {
        query = BuildBaseQuery(request, query);
        
        query["censor"] = ((int)request.CensorType).ToString();
        query["wlist"] = ((int)request.WhiteListType).ToString();
        
        return query;
    }

    private static NameValueCollection BuildBaseQuery(GetAnecdoteRequestBase requestBase, NameValueCollection query)
    {
        query["format"] = requestBase.ResponseFormat.ToString().ToLower();
        query["charset"] = QueryFormatters.GetCorrectFormatCharset(requestBase.CharsetType);

        if (requestBase.CategoryType != CategoryType.All)
            query["category"] = ((int)requestBase.CategoryType).ToString();
        
        if (requestBase.GenreType != GenreType.All)
            query["genre"] = ((int)requestBase.GenreType).ToString();
        
        if (requestBase.Country != Country.All)
            query["country"] = ((int)requestBase.Country).ToString();
        
        query["lang"] = ((int)requestBase.LangType).ToString();
        query["series"] = ((int)requestBase.Series).ToString();
        query["markup"] = ((int)requestBase.MarkupType).ToString();
        query["note"] = ((int)requestBase.NoteType).ToString();
        
        return query;
    }
}