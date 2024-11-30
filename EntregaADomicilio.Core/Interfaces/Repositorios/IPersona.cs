using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPersonaRepositorio
    {
        Task ActualizarAsync(Persona persona);
        Task<int> AgregarAsync(Persona persona);
        Task<Persona> ObtenerPorCorreoAsync(string correo);
        Task<Persona> ObtenerPorIdAsync(string personaId);
    }
}
