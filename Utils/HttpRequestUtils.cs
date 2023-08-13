using System.Text.Json;

namespace PokedexApi.Utils
{
    public static class HttpRequestUtils
    {
        private static readonly HttpClient _httpClient = new();

        
        public static async Task<T> Get<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            string data = await httpResponse.Content.ReadAsStringAsync();
            T parsedData = JsonSerializer.Deserialize<T>(data);

            return parsedData;
        }

        public static async Task<string> GetBase64FromURL(string url)
        {
            Stream stream = await _httpClient.GetStreamAsync(url);;
            byte[] buf;

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                buf = ms.ToArray();
            }

            stream.Close();
            string base64 = Convert.ToBase64String(buf);

            return base64;
        }
    }
}