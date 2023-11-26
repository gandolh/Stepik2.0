using Licenta.Sdk.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Licenta.Sdk.Identity.Keycloak
{
    public class KeycloakHelper
    {
        private readonly KeycloakConfig _keycloakConfig;
        private readonly ILogger _customLogger;
        private KeycloakToken? _token;
        private static HttpClient _httpClient = new HttpClient();
        private JsonSerializerOptions _jsonOptionsToken = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };
        private JsonSerializerOptions jsonOptionsUserRepr = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };


        public KeycloakHelper(IConfiguration config)
        {
            throw new NotImplementedException("Todo: this");
            //CommonWebConfig webConfig = new();
            //config.Bind(webConfig);
            //_keycloakConfig = webConfig.Keycloak;
            //_customLogger = new ConsoleLogger();

        }

        public async Task getAuthorizationToken()
        {
            _customLogger.LogDebug("Initializez prealuarea unui token de autorizare");
            if (_token == null || (int)(DateTime.Now - _token.CreationTime).TotalSeconds >= _token.ExpiresIn)
            {
                _token = await FetchToken(_keycloakConfig.AdminUsername, _keycloakConfig.AdminPassword);
                _token.CreationTime = DateTime.Now;
            }
            else
            {
                if ((int)(DateTime.Now - _token.CreationTime).TotalSeconds >= _token.RefreshTokenExpiresIn)
                    await RefreshToken();
                else
                {
                    _token = await FetchToken(_keycloakConfig.AdminUsername, _keycloakConfig.AdminPassword);
                    _token.CreationTime = DateTime.Now;

                }
            }
            _customLogger.LogDebug("S-a preluat un token de autorizare");
        }


        public async Task<KeycloakUserRepresentation> GetUser(string userId)
        {
            await getAuthorizationToken();
            _customLogger.LogDebug("Caut un utilizator");
            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token?.AccessToken);
            HttpResponseMessage resp = await _httpClient.GetAsync($"{_keycloakConfig.Host}/admin/realms/{_keycloakConfig.Realm}/users/{userId}");

            resp.EnsureSuccessStatusCode();
            _customLogger.LogDebug("S-a gasit un utilizator");
            KeycloakUserRepresentation user = await resp.Content.ReadFromJsonAsync<KeycloakUserRepresentation>() ?? throw new Exception("Cannot deserialize");
            _customLogger.LogDebug("S-a deserializat raspunsul de la keycloak");
            return user;
        }


        public async Task UpdateUser(CurrentUser user)
        {
            string userId = user.Id;
            KeycloakUserRepresentation keycloakRepresentation = await GetUser(userId);
            _customLogger.LogDebug("Incep actualizarea unui utilizator");

            keycloakRepresentation.CopyProprieties(user);
            _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _token?.AccessToken);
            var x = JsonSerializer.Serialize(keycloakRepresentation, jsonOptionsUserRepr);
            HttpResponseMessage resp = await _httpClient.PutAsync($"{_keycloakConfig.Host}/admin/realms/{_keycloakConfig.Realm}/users/{userId}",
                new StringContent(x, Encoding.UTF8, "application/json"));
            //Console.WriteLine("Error: " + resp.Content.ReadAsStringAsync().Result);
            //Console.WriteLine("Error: " + resp.StatusCode);
            _customLogger.LogDebug("Am actualizat utilizatorul");

            resp.EnsureSuccessStatusCode();
        }


        public async Task<bool> CheckPassword(string username, string password)
        {
            _customLogger.LogDebug("Incep verificarea unei parole");
            try
            {
                _token = await FetchToken(username, password);
                _customLogger.LogDebug($"Parola corecta pt {username}");
                return true;

            }
            catch (Exception ex)
            {
                _customLogger.LogDebug($"Parola incorecta pt {username} cu parola: {password}");
                _customLogger.LogError(ex.ToString());
                return false;
            }
        }

        public async Task ChangePassword(string userId, string newPassword)
        {
            await getAuthorizationToken();
            _customLogger.LogDebug("Incep schimbarea parolei");
            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token?.AccessToken);
            // reset password
            string url = $"{_keycloakConfig.Host}/admin/realms/{_keycloakConfig.Realm}/users/{userId}/reset-password";
            var credRepr = new CredentialRepresentation(type: "password", temporary: false, newPassword);
            string reqJson = JsonSerializer.Serialize(credRepr, jsonOptionsUserRepr);

            StringContent content = new StringContent(reqJson, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _httpClient.PutAsync(url, content);
            _customLogger.LogDebug("responsebody: " + resp.Content.ReadAsStringAsync().Result);
            _customLogger.LogDebug("req json: " + reqJson);
            resp.EnsureSuccessStatusCode();
            _customLogger.LogDebug("Parola a fost schimbata");


        }

        #region admin access token

        private async Task RefreshToken()
        {
            var dict = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "client_id", _keycloakConfig.ClientId },
                { "client_secret", _keycloakConfig.ClientSecret },
                { "refresh_token", _token?.RefreshToken },
                { "grant_type", "refresh_token" }
            };

            HttpResponseMessage resp = await _httpClient.PostAsync($"{_keycloakConfig.Host}/realms/{_keycloakConfig.Realm}/protocol/openid-connect/token", new FormUrlEncodedContent(dict));
            resp.EnsureSuccessStatusCode();
            string token_json = await resp.Content.ReadAsStringAsync();
            _token = JsonSerializer.Deserialize<KeycloakToken>(token_json, _jsonOptionsToken) ?? throw new Exception("cannot serialize");
            _token.CreationTime = DateTime.Now;
        }

        private async Task<KeycloakToken> FetchToken(string username, string password)
        {
            var dict = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "client_id", _keycloakConfig.ClientId },
                { "client_secret", _keycloakConfig.ClientSecret  },
                { "username", username },
                { "password", password },
                { "grant_type", "password" }
            };

            HttpResponseMessage resp = await _httpClient.PostAsync($"{_keycloakConfig.Host}/realms/{_keycloakConfig.Realm}/protocol/openid-connect/token", new FormUrlEncodedContent(dict));
            resp.EnsureSuccessStatusCode();
            string token_json = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KeycloakToken>(token_json, _jsonOptionsToken) ?? throw new Exception("cannot serialize");
        }

        public Task<bool> CheckPassword(object username, string password)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
