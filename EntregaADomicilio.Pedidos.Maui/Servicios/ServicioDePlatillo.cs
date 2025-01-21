using EntregaADomicilio.Core.Dtos.Pedidos;
using Newtonsoft.Json;
using System.Collections;

namespace EntregaADomicilio.Pedidos.Maui.Servicios
{
    public class ServicioDePlatillo
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        //Inyectar HttpClient a través del constructor
        public ServicioDePlatillo(IHttpClientFactory httpClientFactory, ServicioDeConfiguracion configuracionServicio)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuracionServicio.ObtenerBaseUrl() + "Platillos/";
        }

        internal async Task<IEnumerable> ObtenerPorCategoriaIdAsync(string id)
        {
            using var client = _httpClientFactory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, _url + $"Categorias/{id}");
            var response = await client.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PlatilloDto>>(await response.Content.ReadAsStringAsync());
            else
                return new List<PlatilloDto>();

        }
    }
}
