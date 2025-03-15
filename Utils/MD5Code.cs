using System.Security.Cryptography;
using System.Text;

namespace AnecdoticaAPI.Utils;

public static class MD5Code
{
    public static string GetMD5Hash(string input)
    {
        using MD5 md5 = MD5.Create();
        
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}