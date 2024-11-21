using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Lab6.Services;

public class GoogleOpenIdService
{
    public static async Task<List<JsonWebKey>> GetPublicKeysFromGoogle(string googlePublicKeysUrl)
    {
        using (var httpClient = new HttpClient())
        {
            // Получаем ключи из Google
            var response = await httpClient.GetStringAsync(googlePublicKeysUrl);
            var jsonResponse = JObject.Parse(response);
            var keys = jsonResponse["keys"].ToObject<List<JsonWebKey>>();
            return keys;
        }
    }
}