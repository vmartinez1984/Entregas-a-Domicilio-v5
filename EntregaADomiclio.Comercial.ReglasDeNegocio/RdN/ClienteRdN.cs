using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN
{
    internal class ClienteRdN : ICliente
    {
        public Task<IdDto> AgregarAsync(ClienteDtoIn cliente)
        {
            throw new NotImplementedException();
        }

        public Task<TokenDto> IniciarSesionAsync(TokenDto inicioDeSesion)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto> ObtenerClientePorId(string clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
