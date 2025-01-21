using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EntregasADomicilio.StoreFiles
{
    public class AlmacenDeArchivosVMtz //: IAlmacenadorDeArchivos
    {
        private readonly string _url;
        private readonly IHttpClientFactory _httpClientFactory;

        public AlmacenDeArchivosVMtz(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _url = configuration.GetSection("urlStorage").Value;
            _httpClientFactory = httpClientFactory;
        }

        public Task Borrar(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarArchivo(string ruta, string contenedor, string extension, byte[] bytesDelArchivo)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Guardar(string contenedor, string nombre, IFormFile formFile)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $@"{_url}/api/Archivos/{contenedor}");
                request.Headers.Add("accept", "*/*");
                var content = new MultipartFormDataContent();
                //content.Add(new StreamContent(File.OpenRead(nombre)), "FormFile",nombre);
                content.Add(new StreamContent(formFile.OpenReadStream()), "FormFile",nombre);
                content.Add(new StringContent(nombre), "NombreDelArchivo");
                request.Content = content;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                else
                    Console.WriteLine(await response.Content.ReadAsStringAsync());

                return Path.Combine(contenedor, nombre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<byte[]> Obtener(string ruta)
        {
            byte[] bytes = null;
            HttpClient client;

            client = new HttpClient();
            bytes = await client.GetByteArrayAsync(_url + "/"+ruta);

            return bytes;
        }
    }
}