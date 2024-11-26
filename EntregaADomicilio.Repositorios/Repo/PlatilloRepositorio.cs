using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EntregaADomicilio.Repositorios.Repo
{
    public class PlatilloRepositorio : IPlatilloRepositorio
    {
        private readonly IMongoCollection<Platillo> _collection;

        public PlatilloRepositorio(IConfiguration configurations)
        {
            var conectionString = configurations.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(conectionString);
            var nombreDeLaDb = conectionString.Split("/").Last().Split("?").First();
            var mongoDatabase = mongoClient.GetDatabase(nombreDeLaDb);
            _collection = mongoDatabase.GetCollection<Platillo>("Platillos");
        }

        public async Task<Platillo> ObtenerPorIdAsync(string platilloId)
        {
            Platillo entidad;

            int id = 0;
            if (int.TryParse(platilloId, out id))
                entidad = (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            else
                entidad = (await _collection.FindAsync(x => x.EncodedKey == platilloId)).FirstOrDefault();

            return entidad;
        }
    }//end class}

    public class BaseRepo
    {
        public readonly IMongoDatabase _database;

        public BaseRepo(IConfiguration configurations)
        {
            var conectionString = configurations.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(conectionString);
            var nombreDeLaDb = conectionString.Split("/").Last().Split("?").First();
            _database = mongoClient.GetDatabase(nombreDeLaDb);            
        }
    }
}