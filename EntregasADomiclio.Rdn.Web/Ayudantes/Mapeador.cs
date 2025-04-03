using EntregaADomicilio.Core.Entidades;
using EntregasADomicilio.Web.Dtos;

namespace EntregasADomiclio.Web.Ayudantes
{
    public static class Mapeador
    {
        public static CategoriaDto ToDto(this Categoria entidad) => entidad is null ? null : new CategoriaDto
        {
            EncodedKey = entidad.EncodedKey,
            Id = entidad.Id.ToString(),
            Nombre = entidad.Nombre
        };
        public static List<CategoriaDto> ToDtos(this List<Categoria> entidades)
            => entidades.Select(x => x.ToDto()).ToList();

        public static ProductoDto ToDto(this Platillo entidad) => entidad is null ? null : new ProductoDto
        {
            Categoria = entidad.Categoria,
            Descripcion = entidad.Descripcion,
            Id = entidad.Id.ToString(),
            Nombre = entidad.Nombre,
            Precio = entidad.Precio,
        };
        public static List<ProductoDto> ToDtos(this List<Platillo> entidades) => entidades.Select(x => x.ToDto()).ToList();
    }
}
