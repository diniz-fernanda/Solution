using Domain.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace Cmd.API
{
    public class CarrinhoApiClient
    {
        private readonly HttpClient _httpClient;

        public CarrinhoApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl = "https://localhost:44355");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Produto>> BuscarTodos()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync("api/carrinho");
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<List<Produto>>();
            }
            else
            {
                throw new Exception($"Erro ao obter os produtos. Status: {resposta.StatusCode}");
            }
        }

        public async Task<Produto> Post(Produto produto)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync("api/carrinho", produto);
            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<Produto>();
            }
            else
            {
                throw new Exception($"Erro ao adicionar o produto. Status: {resposta.StatusCode}");
            }
        }

        public async Task<Produto> Atualizar(Produto produto, int id)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"api/carrinho/{id}", produto);
            if(resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<Produto>();
            }
            else
            {
                throw new Exception($"Erro ao atualizar o produto. Status: {resposta.StatusCode}");
            }
        }

        public async Task<bool> Apagar(int id)
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"api/carrinho/{id}");
            return resposta.IsSuccessStatusCode;
        }
    }
}
