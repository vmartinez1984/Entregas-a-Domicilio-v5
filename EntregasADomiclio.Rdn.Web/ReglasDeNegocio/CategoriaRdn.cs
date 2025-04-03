using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregasADomicilio.Web.Dtos;
using EntregasADomiclio.Web.Ayudantes;

namespace EntregasADomicilio.Web.ReglasDeNegocio
{
    public class CategoriaRdn : BaseRdn
    {
        public CategoriaRdn(IRepositorio repositorio) : base(repositorio)
        {
        }

        public async Task<List<CategoriaDto>> ObtenerAsync()
        {
            List<Categoria> categorias;

            categorias = await _repositorio.Categoria.ObtenerTodosAsync();

            return categorias.ToDtos();
        }
    }
}
