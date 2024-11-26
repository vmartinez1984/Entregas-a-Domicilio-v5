using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface ICliente
    {
        Task<IdDto> AgregarAsync(ClienteDtoIn cliente);
        Task<TokenDto> IniciarSesionAsync(TokenDto inicioDeSesion);
        Task<ClienteDto> ObtenerClientePorId(string clienteId);
    }
}
