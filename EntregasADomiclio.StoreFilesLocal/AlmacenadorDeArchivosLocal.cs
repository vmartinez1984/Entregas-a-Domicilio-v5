//using EntregasADomicilio.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EntregasADomicilio.StoreFiles
{
    public class AlmacenadorDeArchivosLocal //: IAlmacenadorDeArchivos
    {
        private readonly string webRootPat;

        public AlmacenadorDeArchivosLocal(string webRootPat)
        {
            this.webRootPat = webRootPat;
        }        

        public Task Borrar(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarArchivo(string ruta, string contenedor, string extension, byte[] bytesDelArchivo)
        {
            throw new NotImplementedException();
        }      

        public async Task<string> Guardar(string contenedor, string nombreDelArchivo, IFormFile formFile)
        {         
            string folder = Path.Combine(webRootPat, contenedor);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string ruta = Path.Combine(folder, nombreDelArchivo);
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }         

            return $"{contenedor}/{nombreDelArchivo}";
        }

        public async Task<byte[]> Obtener(string ruta)
        {
            byte[] bytes;

            ruta = Path.Combine(webRootPat, ruta);
            bytes = await File.ReadAllBytesAsync(ruta);

            return bytes;
        }
    }
}