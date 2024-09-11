using System.Text;
using System.Text.Json;
using cls.web.plataforma.Data.Interface;
using cls.web.plataforma.Model;
using cls.web.plataforma.Model.Auth;

namespace cls.web.plataforma.Data.Service;
public class AuthService : IAuthService
{
    private readonly IHttpClientFactory _httpClient;

    public AuthService(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Notification<AuthResponse>> Login(string username, string password)
    {
        var output = new Notification<AuthResponse>();
        try
        {
            var client = _httpClient.CreateClient();
            var endpoint = $"login";
            client.BaseAddress = new Uri("https://localhost:7212");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
            var body = new
            {
                login = username,
                password = password
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            httpRequestMessage.Content = content;

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseValue = await httpResponseMessage.Content.ReadAsStreamAsync();
                var response = await JsonSerializer.DeserializeAsync<AuthResponse>(responseValue);
                if (response?.data is null)
                {
                    output.Erro("Token not found");
                    return output;
                }
                output.Sucesso(response);
                return output;
            }

            output.Erro(await httpResponseMessage.Content.ReadAsStringAsync());
            return output;
        }
        catch (Exception err)
        {
            Console.WriteLine("[AuthService]" + err.Message);
            output.Erro("[AuthService] - Exception");
            return output;
        }
    }
}
