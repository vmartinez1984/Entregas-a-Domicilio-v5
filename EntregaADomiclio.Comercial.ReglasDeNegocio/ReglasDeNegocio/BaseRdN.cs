using AutoMapper;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Administracion.ReglasDeNegocio
{
    public class BaseRdN
    {
        public readonly IRepositorio _repositorio;
        public readonly IMapper _mapper;

        public BaseRdN(IRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
    }
}