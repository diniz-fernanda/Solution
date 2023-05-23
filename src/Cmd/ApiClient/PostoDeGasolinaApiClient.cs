using Domain.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Cmd.ApiClient
{
    public class PostoDeGasolinaApiClient
    {
        private readonly HttpClient _httpClient;
        public PostoDeGasolinaApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl = "https://localhost:44355");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<PostoDeGasolina>> BuscarTodosPosto()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync("api/postoDeGasolina");
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<List<PostoDeGasolina>>();
            }
            else
            {
                throw new Exception($"Erro ao obter o Posto De Gasolina. Status: {resposta.StatusCode}");
            }
        }
        public async Task<PostoDeGasolina> BuscarPorIdPostoDeGasolina(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"api/postoDeGasolina/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<PostoDeGasolina>();
            }
            else
            {
                throw new Exception($"Erro ao obter o Posto De Gasolina. Status: {resposta.StatusCode}");
            }
        }
        public async Task<PostoDeGasolina> CadastrarPostoDeGasolina(PostoDeGasolina postoDeGasolina)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync("api/postoDeGasolina", postoDeGasolina);
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<PostoDeGasolina>();
            }
            else
            {
                throw new Exception($"Erro ao adicionar o posto De Gasolina. Status: {resposta.StatusCode}");
            }
        }
        public async Task<PostoDeGasolina> Atualizar(int id, PostoDeGasolina postoDeGasolinaAtualizado)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"api/postoDeGasolina/{id}", postoDeGasolinaAtualizado);

            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<PostoDeGasolina>();
            }
            else
            {
                throw new Exception($"Erro ao atualizar o Posto De Gasolina. Status: {resposta.StatusCode}");
            }
        }

        public async Task<bool> Apagar(int id)
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"api/postoDeGasolina/{id}");
            return resposta.IsSuccessStatusCode;
        }

    }
}

