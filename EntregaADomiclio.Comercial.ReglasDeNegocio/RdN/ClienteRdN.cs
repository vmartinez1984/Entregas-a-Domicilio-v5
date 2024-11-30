using AutoMapper;
using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using JwtTokenServicio.Servicios;

namespace EntregaADomiclio.Pedidos.
{
    internal class ClienteRdN : BaseRdN, ICliente
    {
        private readonly JwtToken _jwtToken;

        public ClienteRdN(
            IRepositorio repositorio,
            IMapper mapper,
            JwtToken jwtToken
        ) : base(repositorio, mapper)
        {
            _jwtToken = jwtToken;
        }

        public async Task<IdDto> AgregarAsync(ClienteDtoIn cliente)
        {
            Persona persona;
            int id;

            persona = _mapper.Map<Persona>(cliente);
            persona.Contrasenia = HashearContraseña(persona.Contrasenia);
            persona.Direcciones.Add(_mapper.Map<Direccion>(cliente.Direccion));
            persona.Direcciones[0].Id = 1;
            persona.EncodedKey = Guid.NewGuid().ToString();
            persona.Direcciones[0].EsLaPrincipal = true;
            id = await _repositorio.Persona.AgregarAsync(persona);

            return new IdDto { EncodedKey = cliente.EncodedKey, Id = id.ToString() };
        }

        /// <summary>
        /// Aqui se implementa un hasheo pero de momento se mantendra plano
        /// </summary>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        private string HashearContraseña(string contrasenia)
        {
            return contrasenia;
        }

        public async Task<TokenDto> IniciarSesionAsync(InicioDeSesionDtoIn inicioDeSesion)
        {
            Persona persona;

            persona = await _repositorio.Persona.ObtenerPorCorreoAsync(inicioDeSesion.Correo);
            if (EsValidaLaContrasenia(persona.Contrasenia, inicioDeSesion.Contrasenia))
                return ObtenerToken(persona);
            else
                return null;
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
            keyValuePairs.Add("Role", "Cliente");
            keyValuePairs.Add("ClienteId", persona.EncodedKey);
            token = _jwtToken.ObtenerToken(keyValuePairs, fechaDeVencimiento);
            tokenDto = new TokenDto
            {
                Token = token,
                FechaDeVencimiento = fechaDeVencimiento.ToString()
            };

            return tokenDto;
        }

        public async Task<ClienteDto> ObtenerClientePorId(string clienteId) {
            Persona persona;
            ClienteDto cliente;

            persona = await _repositorio.Persona.ObtenerPorIdAsync(clienteId); 
            cliente = _mapper.Map<ClienteDto>(persona);
            cliente.Direccion = _mapper.Map<DireccionDto>(persona.Direcciones[0]);
            
            return cliente;
        }

        public async Task ActualizarAsync(string clienteId, ClienteDtoUpd cliente)
        {
            Persona persona;

            persona = await _repositorio.Persona.ObtenerPorIdAsync(clienteId);
            persona = _mapper.Map(cliente, persona);
            persona.Direcciones[0] = _mapper.Map(cliente.Direccion,persona.Direcciones[0]);

            await _repositorio.Persona.ActualizarAsync(persona);
        }
    }
}
