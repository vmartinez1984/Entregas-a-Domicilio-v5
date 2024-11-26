using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Bl
{
    public class UnitOfWork //: IReglasDeNegocio
    {
        public ICategoriaRdN Categoria { get; }
    }
}
