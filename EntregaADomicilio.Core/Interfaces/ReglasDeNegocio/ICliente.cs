using EntregaADomicilio.Core.Dtos.Administracion;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface ICliente
    {
        Task ActualizarAsync(string clienteId, ClienteDtoUpd cliente);
        Task<IdDto> AgregarAsync(ClienteDtoIn cliente);
        Task<TokenDto> IniciarSesionAsync(InicioDeSesionDtoIn inicioDeSesion);
        Task<ClienteDto> ObtenerClientePorId(string clienteId);
    }
}
