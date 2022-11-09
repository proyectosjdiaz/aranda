using Aranda.Front.Model;
using Newtonsoft.Json;
using System.Text;

namespace Aranda.Front.Service
{
    public class ServiceCategoria : IServiceCategoria
    {
        private readonly string endpoint = "categoria";
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceCategoria(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("ApiUrl");
        }

        public async Task<IEnumerable<CategoriaModel>> Categorias()
        {
            using var response = await _httpClient.GetAsync($"{endpoint}/categorias");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var categorias = JsonConvert.DeserializeObject<IEnumerable<CategoriaModel>>(responseString);
            return categorias;
        }

        public async Task<CategoriaModel> Categoria(int id)
        {
            using var response = await _httpClient.GetAsync($"{endpoint}/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var categorias = JsonConvert.DeserializeObject<CategoriaModel>(responseString);
            return categorias;
        }

        public async Task<CategoriaModel> Actualizar(CategoriaModel body)
        {
            StringContent content = new(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync($"{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<CategoriaModel>(responseString);
            return categoria;
        }

        public async Task<CategoriaModel> Crear(CategoriaModel body)
        {
            StringContent content = new(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync($"{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<CategoriaModel>(responseString);
            return categoria;
        }

        public async Task<bool> Eliminar(int id)
        {
            using var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var success = JsonConvert.DeserializeObject<bool>(responseString);
            return success;
        }
    }
}
