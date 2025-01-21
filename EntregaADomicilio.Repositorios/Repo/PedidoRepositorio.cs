using EntregaADomicilio.Core.Constantes;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EntregaADomicilio.Repositorios.Repo
{
    public class PedidoRepositorio : BaseRepo, IPedidoRepositorio
    {
        private readonly IMongoCollection<Pedido> _collection;

        public PedidoRepositorio(IConfiguration configurations) : base(configurations)
        {
            _collection = _database.GetCollection<Pedido>("Pedidos");
        }

        public async Task ActualizarAsync(Pedido entidad) => await _collection.ReplaceOneAsync(x => x.EncodedKey == entidad.EncodedKey || x.Id == entidad.Id, entidad);

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

        public async Task<List<Pedido>> ObtenerPedidosPorEstadoYRepartidorId(string repartidorId, string estado)
            =>
         await _collection
                .Find(x => x.RepartidorId == repartidorId && x.Estado == estado)
                .SortByDescending(x => x.FechaDeRegistro)
                .ToListAsync();

        public async Task<List<Pedido>> ObtenerPedidosPreparadoAsync() =>
            await _collection.Find(x => x.Estado == EstadoDelPedido.Preparado).ToListAsync();

        public async Task<Pedido> ObtenerPorIdAsync(string pedidoId)
        {
            Pedido entidad;

            int id = 0;
            if (int.TryParse(pedidoId, out id))
                entidad = (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            else
                entidad = (await _collection.FindAsync(x => x.EncodedKey == pedidoId)).FirstOrDefault();

            return entidad;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(string clienteId)
        {
            List<Pedido> pedidos;

            int id = 0;
            if (int.TryParse(clienteId, out id))
                pedidos = await _collection.Find(x => x.Cliente.Id == id)
                    .SortByDescending(x => x.FechaDeRegistro)
                    .ToListAsync();
            else
                pedidos = await _collection.Find(x => x.Cliente.EncodedKey == clienteId)
                    .SortByDescending(x => x.FechaDeRegistro)
                    .ToListAsync();

            return pedidos;
        }

        public async Task<Pedido> ObtenerUltimoPedidoAsync(string clienteId)
        {
            Pedido entidad;

            int id = 0;
            if (int.TryParse(clienteId, out id))
                entidad = await _collection.Find(x => x.Cliente.Id == id)
                    .SortByDescending(x => x.FechaDeRegistro)
                    .FirstOrDefaultAsync();
            else
                entidad = await _collection.Find(x => x.Cliente.EncodedKey == clienteId)
                    .SortByDescending(x => x.FechaDeRegistro)
                    .FirstOrDefaultAsync();

            return entidad;
        }
    }//end class   
}