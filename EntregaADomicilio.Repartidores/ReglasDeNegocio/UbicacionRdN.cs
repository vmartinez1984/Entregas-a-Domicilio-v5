using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidores.ReglasDeNegocio
{
    public class UbicacionRdN : BaseRdN
    {
        public UbicacionRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task<IdDto> AgregarAsync(string repartidorId, string pedidoId, UbicacionDto ubicacion)
        {
            Ubicacion entidad;

            entidad = await _repositorio.Ubicacion.ObtenerPorPedidoIdAsync(pedidoId);
            if (entidad == null)
            {
                entidad = new Ubicacion
                {
                    EncodedKey = Guid.NewGuid().ToString(),
                    PedidoId = pedidoId,
                    RepartidorId = repartidorId,
                    Coordenadas = new List<Coordenada> { new Coordenada { CoordenadasGps = ubicacion.CoordenadasGps, Id = 1 } }
                };

                entidad.Id = await _repositorio.Ubicacion.AgregarAsync(entidad);
            }
            else
            {
                entidad.Coordenadas.Add(new Coordenada { CoordenadasGps = ubicacion.CoordenadasGps, Id = entidad.Coordenadas.Count() + 1 });

                await _repositorio.Ubicacion.ActualizarAsync(entidad);
            }

            return new IdDto
            {
                EncodedKey = entidad.EncodedKey,
                Id = entidad.Coordenadas.Count()
            };
        }
    }
}
