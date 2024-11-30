using EntregaADomicilio.Core.Dtos.Administracion;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface IPlatillo
    {
        Task<List<PlatilloDto>> ObtenerTodosAsync();

        Task<PlatilloDto> ObtenerPorIdAsync(string platilloId);

        Task<byte[]> ObtenerImagenPorIdAsync(string platilloId);

        Task<List<PlatilloDto>> ObtenerPorCategoriaIdAsync(string categoriaId);

        Task<IdDto> AgregarAsync(PlatilloDtoIn platillo);
        Task ActualizarAsync(string id, PlatilloDtoUpdate platillo);
    }
}
