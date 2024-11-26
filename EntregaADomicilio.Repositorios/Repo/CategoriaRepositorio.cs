using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EntregaADomicilio.Repositorios.Repo
{
    public class CategoriaRepositorio : BaseRepo, ICategoriaRepositorio
    {
        private readonly IMongoCollection<Categoria> _collection;

        public CategoriaRepositorio(IConfiguration configurations) : base(configurations)
        {
            _collection = _database.GetCollection<Categoria>("Categorias");
        }


        //public CategoriaRepositorio(IConfiguration configurations)
        //{
        //    var conectionString = configurations.GetConnectionString("MongoDb");
        //    var mongoClient = new MongoClient(conectionString);
        //    var nombreDeLaDb = conectionString.Split("/").Last().Split("?").First();
        //    var mongoDatabase = mongoClient.GetDatabase(nombreDeLaDb);
        //    _collection = mongoDatabase.GetCollection<Categoria>("Categorias");
        //}

        public async Task ActualizarAsync(Categoria entidad)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entidad.Id, entidad);
        }

        public async Task<string> AgregarAsync(Categoria item)
        {
            if (item.Id == 0)
                item.Id = await ObtenerId();
            await _collection.InsertOneAsync(item);

            return item.Id.ToString();
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

        public Task<bool> ExisteAsync(string categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> ObtenerPorIdAsync(string categoriaId)
        {
            Categoria categoria;
            int id = 0;

            if (int.TryParse(categoriaId, out id))
                categoria = (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            else
                categoria = (await _collection.FindAsync(x => x.EncodedKey == categoriaId)).FirstOrDefault();

            return categoria;
        }


        public async Task<List<Categoria>> ObtenerTodosAsync() => (await _collection.FindAsync(_ => true)).ToList();

    }//end class
}