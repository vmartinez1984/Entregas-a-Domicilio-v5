using EntregaADomicilio.Core.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class ServicioDePedido
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;


        /// <summary>
        /// Inyectar HttpClient a través del constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="configuracionServicio"></param>
        public ServicioDePedido(IHttpClientFactory httpClientFactory, ServicioDeConfiguracion configuracionServicio)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuracionServicio.ObtenerBaseUrl() + "Pedidos/";
        }

        public async Task<List<PedidoDto>> ObtenerTodos()
        {
            List<PedidoDto> lista;
            HttpRequestMessage request;
            HttpResponseMessage response;
            HttpClient httpClient;

            httpClient = _httpClientFactory.CreateClient();

            
        }
    }
}
