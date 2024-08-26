using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

using cls.web.plataforma.Data.Interface;
using cls.web.plataforma.Model;
using System.Text;
using System.Net.Http.Headers;


namespace cls.web.plataforma.Data.Service
{
    public class PersonResponse
    {
        public Pessoa[]? data { get; set; }

    }
    public class PessoaService : IPessoaService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ISessionContext _sessionContext;

        public PessoaService(IHttpClientFactory httpClient, ISessionContext sessionContext)
        {
            _httpClient = httpClient;
            _sessionContext = sessionContext;
        }
        public async Task<bool> Update(string id, Pessoa pessoa)
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"pessoa/{id}";
                client.BaseAddress = new Uri("https://localhost:7192");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, endpoint);
                var content = new StringContent(JsonSerializer.Serialize(pessoa), Encoding.UTF8, "application/json");
                httpRequestMessage.Content = content;
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _sessionContext.Get());

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch (Exception err)
            {
                throw new Exception("PersonService", err);
            }
        }

        public async Task<bool> Save(Pessoa pessoa)
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"pessoa/";
                client.BaseAddress = new Uri("https://localhost:7192");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _sessionContext.Get());
                var content = new StringContent(JsonSerializer.Serialize(pessoa), Encoding.UTF8, "application/json");
                httpRequestMessage.Content = content;

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch (Exception err)
            {
                throw new Exception("PersonService", err);
            }
        }

        public async Task<bool> Delete(string? id)
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"pessoa/{id}";
                client.BaseAddress = new Uri("https://localhost:7192");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, endpoint);
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _sessionContext.Get());

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch (Exception err)
            {
                throw new Exception("PersonService", err);
            }

        }
        public async Task<Pessoa> GetById(string id)
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"pessoa?id={id}";
                client.BaseAddress = new Uri("https://localhost:7192");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _sessionContext.Get());

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseValue = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var response = await JsonSerializer.DeserializeAsync<PersonResponse>(responseValue);
                    return response.data.First() ?? default;
                }

                return default;
            }
            catch (Exception err)
            {
                throw new Exception("PersonService", err);
            }
        }

        public async Task<Pessoa[]> Get()
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"pessoa";
                client.BaseAddress = new Uri("https://localhost:7192");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _sessionContext.Get());

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseValue = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var response = await JsonSerializer.DeserializeAsync<PersonResponse>(responseValue);
                    return response.data ?? default;
                }

                return default;
            }
            catch (Exception err)
            {
                //throw new Exception("PersonService", err);
                return default;
            }
        }

    }
}
