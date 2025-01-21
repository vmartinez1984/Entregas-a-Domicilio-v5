using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Pedidos.Maui.Servicios
{
    public class ServicioDeConfiguracion
    {
        public string ObtenerBaseUrl()
        {
#if WINDOWS
            return "https://localhost:7103/api/";
#else
            return "https://10.0.2.2:5001/api/";
#endif
        }

        public string ObtenerUrl(string uri)
        {
            string baseUrl;

            baseUrl = ObtenerBaseUrl();

            uri = uri.TrimStart('/');
            if (uri.StartsWith("api"))
               uri = uri.Remove(0, 3);
            uri = uri.TrimStart('/');

            return baseUrl + uri;
        }
        private TokenDto token;
        public TokenDto ObtenerToken() { return this.token; }

        public void ColocarToken(TokenDto token) { this.token = token; }
    }
}
