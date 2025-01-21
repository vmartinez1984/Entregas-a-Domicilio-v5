//using EntregasADomicilio.Core.Interfaces;
using Minio;

namespace EntregasADomicilio.StoreFiles
{
    public class AlmacenDeArchivosS3 //: IAlmacenadorDeArchivosS3
    {
        MinioClient _minio;

        public AlmacenDeArchivosS3()
        {
            IniciarMinio();
        }

        private void IniciarMinio()
        {
            string url;
            string accessKey;
            string secretKey;
            url = "127.0.0.1:9000";
            accessKey = "nPSktppiEAtAwnT3lBN4";
            secretKey = "v1oIvbRwHDREddFvUWp7mVoGhotE6rS7bBUgmRt6";
            _minio = new MinioClient()
                     .WithEndpoint(url)
                     .WithCredentials(accessKey, secretKey)
                     .WithSSL(false)
                     .Build();
        }

        public Task Borrar(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarArchivo(string ruta, string contenedor, string extension, byte[] bytesDelArchivo)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> ObtenerBytes(string contenedor, string nombreDelArchivo)
        {
            byte[] bytes = null;

            try
            {
                //var objstatreply = await _minio.StatObjectAsync(new StatObjectArgs()
                //  .WithBucket(contenedor)
                //  .WithObject(nombreDelArchivo)          
                //);

                //if (objstatreply == null || objstatreply.DeleteMarker)
                //    throw new Exception("object not found or Deleted");

                var data = await _minio.GetObjectAsync(
                    new GetObjectArgs()
                    .WithBucket(contenedor)
                    .WithObject(nombreDelArchivo)
                    .WithCallbackStream((stream) =>
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();
                        }
                    })
                );
            }
            catch (Exception ex)
            {

               // throw;
            }

            return bytes;
        }

        public async Task<string> Guardar(string bucketName,string nombreDelArchivo, Microsoft.AspNetCore.Http.IFormFile formFile)
        {
            var beArgs = new BucketExistsArgs()
            .WithBucket(bucketName);
            bool found = await _minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(bucketName);
                await _minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            var contentType = "application/octet-stream";            
            var response = await _minio.PutObjectAsync(
              new PutObjectArgs()
            .WithBucket(bucketName)
              //.WithObject(formFile.FileName)              
              .WithObject(nombreDelArchivo)
              .WithStreamData(formFile.OpenReadStream())
              .WithObjectSize(formFile.Length)
              .WithContentType(contentType)              
            );

            return response.ObjectName;
        }


    }
}
