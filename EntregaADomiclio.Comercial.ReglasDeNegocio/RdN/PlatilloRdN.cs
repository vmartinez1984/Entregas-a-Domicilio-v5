using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN
{
    internal class PlatilloRdN : IPlatillo
    {
        public Task ActualizarAsync(string id, PlatilloDtoUpdate platillo)
        {
            throw new NotImplementedException();
        }

        public Task<IdDto> AgregarAsync(PlatilloDtoIn platillo)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ObtenerImagenPorIdAsync(string platilloId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaDto>> ObtenerPorCategoriaIdAsync(string categoriaId)
        {
            throw new NotImplementedException();
        }

        public Task<PlatilloDto> ObtenerPorIdAsync(string platilloId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaDto>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
