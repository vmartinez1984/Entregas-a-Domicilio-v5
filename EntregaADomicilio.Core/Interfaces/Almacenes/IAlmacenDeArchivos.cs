using Microsoft.AspNetCore.Http;

namespace EntregaADomicilio.Core.Interfaces.Almacenes
{
    public interface IAlmacenDeArchivos
    {
        Task<string> Guardar(string bucketName, string nombreDelArchivo, IFormFile formFile);

        Task<byte[]> ObtenerBytes(string ruta);

        Task Borrar(string ruta, string contenedor);
    }
}