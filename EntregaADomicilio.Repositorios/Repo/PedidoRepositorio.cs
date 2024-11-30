using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EntregaADomicilio.Repositorios.Repo
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly IMongoCollection<Pedido> _collection;

        public PedidoRepositorio(IConfiguration configurations)
        {
            var conectionString = configurations.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(conectionString);
            var nombreDeLaDb = conectionString?.Split("/").Last().Split("?").First();
            var mongoDatabase = mongoClient.GetDatabase(nombreDeLaDb);
            _collection = mongoDatabase.GetCollection<Pedido>("Pedidos");
        }

        public async Task ActualizarAsync(Pedido entidad) => await _collection.ReplaceOneAsync(x => x.Id == entidad.Id, entidad);

        public async Task<int> AgregarAsync(Pedido item)
        {
            if (item.Id == 0)
                item.Id = await ObtenerId();
            await _collection.InsertOneAsync(item);

            return item.Id;
        }

        public async Task<int> ObtenerId()
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

        public async Task<Pedido> ObtenerPorIdAsync(string platilloId)
        {
            Pedido entidad;

            int id = 0;
            if (int.TryParse(platilloId, out id))
                entidad = (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            else
                entidad = (await _collection.FindAsync(x => x.EncodedKey == platilloId)).FirstOrDefault();

            return entidad;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync() => (await _collection.FindAsync(_ => true)).ToList();
       

    }//end class   
}