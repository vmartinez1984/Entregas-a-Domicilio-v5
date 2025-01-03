using EntregaADomicilio.Core.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class ServicioDeConfiguracion
    {
        public string ObtenerBaseUrl()
        {         
            return "https://localhost:7209/api/";
        }

        private TokenDto token;
        public TokenDto ObtenerToken() { return this.token; }

        public void ColocarToken(TokenDto token) {this.token = token;}
    }
}
