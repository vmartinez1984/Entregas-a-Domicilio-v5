using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EntregaADomicilio.Repositorios.Repo
{
    public class PersonaRepositorio : BaseRepo, IPersonaRepositorio
    {
        private readonly IMongoCollection<Persona> _collection;
        public PersonaRepositorio(IConfiguration configurations) : base(configurations)
        {
            _collection = _database.GetCollection<Persona>("Personas");
        }

        public async Task ActualizarAsync(Persona entidad) => await _collection.ReplaceOneAsync(x => x.Id == entidad.Id, entidad);

        public async Task<int> AgregarAsync(Persona item)
        {
            if (item.Id == 0)
                item.Id = await ObtenerId();
            await _collection.InsertOneAsync(item);

            return item.Id;
        }

        public async Task<Persona> ObtenerPorCorreoAsync(string correo) => (await _collection.FindAsync(x => x.Correo == correo)).FirstOrDefault();

        public async Task<Persona> ObtenerPorIdAsync(string clienteId)
        {
            int id = 0;
            Persona persona;

            if (int.TryParse(clienteId, out id))
                persona = (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            else
                persona = (await _collection.FindAsync(x => x.EncodedKey == clienteId)).FirstOrDefault();

            return persona;
        }

        private async Task<int> ObtenerId()
        {
            var item = await
            _collection
            .Find(new BsonDocument()) // Puedes agregar filtros si es necesario
            .SortByDescending(r => r.Id) // Ordenar por fecha de forma descendente
            .FirstOrDefaultAsync();
            ;
            if (item == null)
                return 1;

            return item.Id + 1;
        }

    }
}
