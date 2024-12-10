using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Repartidores.Dtos;
using JwtTokenServicio.Servicios;

namespace EntregaADomicilio.Repartidores.ReglasDeNegocio
{
    public class RepartidorRdN: BaseRdN
    {
        private readonly JwtToken _jwtToken;

        public RepartidorRdN(
            IRepositorio repositorio,
            IMapper mapper,
            JwtToken jwtToken
        ) : base(repositorio, mapper)
        {
            _jwtToken = jwtToken;
        }

        public async Task AceptarPedidoAsync(string repartidorID, string pedidoId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPorIdAsync(pedidoId);
            pedido.RepartidorId = repartidorID;
            pedido.Estado = "En camino";
            pedido.FechaDeActualizacion = DateTime.Now;

            await _repositorio.Pedido.ActualizarAsync(pedido);
        }

        public async Task<TokenDto> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion)
        {
            Persona persona;

            persona = await _repositorio.Persona.ObtenerPorCorreoAsync(inicioDeSesion.Correo);
            if (persona is null)
                return null;
            if (EsValidaLaContrasenia(persona.Contrasenia, inicioDeSesion.Contrasenia))
                return ObtenerToken(persona);
            else
                return null;
        }

        public async Task<PedidoDto> ObtenerAsync(string repartidorId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPedidoPreparadoAsync(repartidorId);

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task PedidoEntregadoAsync(string pedidoId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPorIdAsync(pedidoId);            
            pedido.Estado = "Entregado";
            pedido.FechaDeActualizacion = DateTime.Now;

            await _repositorio.Pedido.ActualizarAsync(pedido);
        }

        private bool EsValidaLaContrasenia(string contrasenia1, string contrasenia2)
        {
            //En teoria la contrasenia1 esta encriptada, entonces se tendria que hacer el debido proceso, pero por practicidad se hara plano
            return contrasenia1 == contrasenia2;
        }

        private TokenDto ObtenerToken(Persona persona)
        {
            TokenDto tokenDto;
            string token;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            DateTime fechaDeVencimiento = DateTime.Now.AddMinutes(20);

            keyValuePairs.Add("Nombre", persona.Nombre + " " + persona.Apellidos);
            keyValuePairs.Add("Correo", persona.Correo);
            keyValuePairs.Add("Role", "Repartidor");
            keyValuePairs.Add("RepartidorId", persona.EncodedKey);
            token = _jwtToken.ObtenerToken(keyValuePairs, fechaDeVencimiento);
            tokenDto = new TokenDto
            {
                Token = token,
                FechaDeVencimiento = fechaDeVencimiento.ToString()
            };

            return tokenDto;
        }

    }
}
