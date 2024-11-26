using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface IPlatillo
    {
        Task<List<CategoriaDto>> ObtenerTodosAsync();

        Task<PlatilloDto> ObtenerPorIdAsync(string platilloId);

        Task<byte[]> ObtenerImagenPorIdAsync(string platilloId);

        Task<List<CategoriaDto>> ObtenerPorCategoriaIdAsync(string categoriaId);

        Task<IdDto> AgregarAsync(PlatilloDtoIn platillo);
        Task ActualizarAsync(string id, PlatilloDtoUpdate platillo);
    }
}
