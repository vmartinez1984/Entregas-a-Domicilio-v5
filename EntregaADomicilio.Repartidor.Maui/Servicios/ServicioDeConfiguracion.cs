using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class ServicioDeConfiguracion
    {
        public string ObtenerBaseUrl()
        {
            //return "https://localhost:7209/api/";
            //return "https://192.168.1.77:7209/api/";
            //return "http://192.168.1.77:32768/api/";
            return "https://10.0.2.2:5001/api/";
        }

        private TokenDto token;
        public TokenDto ObtenerToken() { return this.token; }

        public void ColocarToken(TokenDto token) {this.token = token;}
    }
}
