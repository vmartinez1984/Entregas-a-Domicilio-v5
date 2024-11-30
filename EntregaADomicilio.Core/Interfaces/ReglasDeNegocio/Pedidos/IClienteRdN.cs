using EntregaADomicilio.Core.Dtos.Administracion;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio.Pedidos
{
    public interface IClienteRdN
    {
        Task ActualizarAsync(string clienteId, ClienteDtoUpd cliente);
        Task<IdDto> AgregarAsync(ClienteDtoIn cliente);
        Task<TokenDto> IniciarSesionAsync(InicioDeSesionDtoIn inicioDeSesion);
        Task<ClienteDto> ObtenerClientePorId(string clienteId);
    }
}
