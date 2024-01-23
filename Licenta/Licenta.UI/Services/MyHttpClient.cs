using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using System;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Licenta.UI.Services
{
    public class MyHttpClient
    {
        protected readonly JsonSerializerOptions jsonSerializerOptions =
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _httpClient;

        public MyHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler);
        }


        private Task<string> AddQuerryParamsIfExists(string url, Dictionary<string, string>? parameters)
        {
            string userId = User.UserId;
            bool? userIdFound = parameters?.TryGetValue(nameof(userId), out _);
            if (userId != "" && userIdFound != true)
            {
                parameters = parameters ?? new Dictionary<string, string>();
                parameters.Add("userId", userId);
            }
            if (parameters != null)
                url = url + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
            return Task.FromResult(url);
        }



        private async Task<HttpResponseMessage> BaseGet(string url)
        {
            Console.WriteLine("S-a inceput un request de tip Get pentru: " + url);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;

        }
        private async Task<HttpResponseMessage> BasePost(string url, StringContent data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = data;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        #region GET

        public async Task<T> GetAsync<T>(string url, Dictionary<string, string>? parameters = null)
        {
            url = await AddQuerryParamsIfExists(url, parameters);
            HttpResponseMessage response = await BaseGet(url);
            string respJson = await response.Content.ReadAsStringAsync();
            T resp = JsonSerializer.Deserialize<T>(respJson, jsonSerializerOptions)
                ?? throw new Exception("Cannot deserialize json from web request");
            return resp;
        }
        public async Task<Stream> getStreamAsync(string url, Dictionary<string, string>? parameters = null)
        {
            url = await AddQuerryParamsIfExists(url, parameters);
            HttpResponseMessage response = await BaseGet(url);
            return await response.Content.ReadAsStreamAsync();
        }
        public async Task<string> GetAsync(string url, Dictionary<string, string>? parameters = null)
        {
            url = await AddQuerryParamsIfExists(url, parameters);
            HttpResponseMessage response = await BaseGet(url);
            return await response.Content.ReadAsStringAsync();

        }
        #endregion
        #region POST
        public async Task<T> PostAsync<T, U>(string url, U data)
        {
            var json = JsonSerializer.Serialize(data);
            var response = await BasePost(url, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string respJson = await response.Content.ReadAsStringAsync();
            T resp = JsonSerializer.Deserialize<T>(respJson, jsonSerializerOptions)
                ?? throw new Exception("Cannot deserialize json from web request");
            return resp;
        }
        public async Task<string> PostAsync<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var response = await BasePost(url, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PostAsync(string url, string data)
        {
            var json = JsonSerializer.Serialize(data);
            var response = await BasePost(url, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<T> PostAsync<T>(string url, MultipartFormDataContent data)
        {
            string opId = Guid.NewGuid().ToString();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = data;
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            T resp = JsonSerializer.Deserialize<T>(json, jsonSerializerOptions)
                ?? throw new Exception("Cannot deserialize json from web request");
            return resp;
        }

        public async Task<Stream> PostStreamAsync<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            StringContent stringContentData = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = stringContentData;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }


        #endregion
        #region PUT
        internal async Task<string> PutAsync<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var response = await BasePost(url, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
           return await response.Content.ReadAsStringAsync();
        }
        #endregion
        #region Delete

        #endregion
    }
}
