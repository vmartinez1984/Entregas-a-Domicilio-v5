using EntregaADomicilio.Core.Interfaces.Almacenes;
using Microsoft.AspNetCore.Http;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Servicios
{
    internal class AlmacenDeArchivoServicio : IAlmacenDeArchivos
    {
        public Task Borrar(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> Guardar(string bucketName, string nombreDelArchivo, IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ObtenerBytes(string contenedor, string nombreDelArchivo)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ObtenerBytes(string ruta)
        {
            throw new NotImplementedException();
        }
    }
}