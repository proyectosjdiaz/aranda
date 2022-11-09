using Aranda.Front.Model;
using Newtonsoft.Json;
using System.Text;

namespace Aranda.Front.Service
{
    public class ServiceProducto : IServiceProducto
    {
        private readonly string endpoint = "producto";
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceProducto(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("ApiUrl");
        }

        public async Task<IEnumerable<ProductoModel>> Productos()
        {
            using var response = await _httpClient.GetAsync($"{endpoint}/productos");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<IEnumerable<ProductoModel>>(responseString);
            return productos;
        }

        public async Task<ProductoModel> Producto(int id)
        {
            using var response = await _httpClient.GetAsync($"{endpoint}/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoModel>(responseString);
            return producto;
        }

        public async Task<ProductoModel> Actualizar(ProductoModel body)
        {
            StringContent content = new(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync($"{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoModel>(responseString);
            return producto;
        }

        public async Task<ProductoModel> Crear(ProductoModel body)
        {
            StringContent content = new(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync($"{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoModel>(responseString);
            return producto;
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
