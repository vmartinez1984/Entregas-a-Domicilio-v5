namespace EntregasADomicilio.Web.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public CategoriaRdn Categoria { get; set; }

        public ProductosRdn Producto { get; set; }

        public UnitOfWork(CategoriaRdn categoriaRdn, ProductosRdn productosRdn)
        {
            Categoria = categoriaRdn;
            Producto = productosRdn;
        }
    }
}
