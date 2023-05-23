using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using Domain.Model;

namespace Cmd.ApiClient
{
    public class CarroApiClient
    {
        private readonly HttpClient _httpClient;
        public CarroApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl = "https://localhost:44355");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        public async Task <List<Carro>> BuscarTodosPosto()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync("api/carro");
            if(resposta.IsSuccessStatusCode) 
            {
                return await resposta.Content.ReadFromJsonAsync<List<Carro>>();
            }
            else
            {
                throw new Exception($"Erro ao obter os carros. Status: {resposta.StatusCode}");
            }
        }
        public async Task<Carro> BuscarPorIdCarro(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"api/carro/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<Carro>();
            }
            else
            {
                throw new Exception($"Erro ao obter o carro. Status: {resposta.StatusCode}");
            }
        }
        public async Task<List<Carro>> CadastrarCarro(Carro[] carro)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync("api/carro", carro);
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<List<Carro>>();
            }
            else
            {
                throw new Exception($"Erro ao adicionar o carro. Status: {resposta.StatusCode}");
            }
        }
        public async Task<Carro> Atualizar(int id, Carro carroAtualizado)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"api/carro/{id}", carroAtualizado);

            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<Carro>();
            }
            else
            {
                throw new Exception($"Erro ao atualizar o carro. Status: {resposta.StatusCode}");
            }
        }

        public async Task<bool> Apagar(int id)
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"api/carro/{id}");
            return resposta.IsSuccessStatusCode;
        }

    }
}
