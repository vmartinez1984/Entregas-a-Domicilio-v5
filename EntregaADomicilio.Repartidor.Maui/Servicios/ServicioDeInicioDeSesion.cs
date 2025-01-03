using EntregaADomicilio.Core.Repartidores.Dtos;
using Newtonsoft.Json;

namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class ServicioDeInicioDeSesion
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        //Inyectar HttpClient a través del constructor
        public ServicioDeInicioDeSesion(IHttpClientFactory httpClientFactory, ServicioDeConfiguracion configuracionServicio)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuracionServicio.ObtenerBaseUrl() + "Repartidores/";
        }

        public async Task<TokenDto> IniciarSesionAsync(string correo, string contraseña)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _url + "IniciarSesiones");
                var inicioDeSesion = new InicioDeSesionDto { Correo = correo, Contrasenia = contraseña };
                var body = JsonConvert.SerializeObject(inicioDeSesion);
                var content = new StringContent(body, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    TokenDto id;

                    id = JsonConvert.DeserializeObject<TokenDto>(data);
                    if (id == null)
                        return null;

                    return id;
                }
                else
                    //throw new Exception(await response.Content.ReadAsStringAsync());
                    return null;
            }
        }
    }
}
