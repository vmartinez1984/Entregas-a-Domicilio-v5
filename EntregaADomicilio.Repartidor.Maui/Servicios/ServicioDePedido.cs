using EntregaADomicilio.Core.Repartidores.Dtos;
using Newtonsoft.Json;

namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class ServicioDePedido
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServicioDeConfiguracion _configuracionServicio;
        private readonly string _url;


        /// <summary>
        /// Inyectar HttpClient a través del constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="configuracionServicio"></param>
        public ServicioDePedido(IHttpClientFactory httpClientFactory, ServicioDeConfiguracion configuracionServicio)
        {
            _httpClientFactory = httpClientFactory;
            _configuracionServicio = configuracionServicio;
            _url = configuracionServicio.ObtenerBaseUrl() + "Pedidos/";
        }

        public async Task<List<PedidoDto>> ObtenerTodosAsync()
        {            
            HttpRequestMessage request;
            HttpResponseMessage response;
            HttpClient httpClient;
            string data;

            httpClient = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, _url);
            request.Headers.Add("Authorization", $"Bearer {_configuracionServicio.ObtenerToken().Token}");
            response = await httpClient.SendAsync(request);
            data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)            
                return JsonConvert.DeserializeObject<List<PedidoDto>>(data);
            else
                throw new Exception(data);

        }
    }
}
