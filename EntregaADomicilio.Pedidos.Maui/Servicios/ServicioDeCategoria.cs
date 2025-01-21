using EntregaADomicilio.Core.Dtos.Pedidos;
using Newtonsoft.Json;

namespace EntregaADomicilio.Pedidos.Maui.Servicios
{
    public class ServicioDeCategoria
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        //Inyectar HttpClient a través del constructor
        public ServicioDeCategoria(IHttpClientFactory httpClientFactory, ServicioDeConfiguracion configuracionServicio)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuracionServicio.ObtenerBaseUrl() + "Categorias/";
        }

        public async Task<List<CategoriaDto>> ObtenerTodosAsync()
        {
            using var client = _httpClientFactory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, _url);
            var response = await client.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<CategoriaDto>>(await response.Content.ReadAsStringAsync());
            else
                return new List<CategoriaDto>();

            //return await Task.FromResult(new List<CategoriaDto> {
            //    new CategoriaDto{
            //        Id = "Entradas",
            //        Nombre= "Entradas",
            //        Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/yakimeshicalofornia-1200x1200px-00377907776449764.png"
            //    },
            //    new CategoriaDto{
            //        Id = "Ensaladas",
            //        Nombre= "Ensaladas",
            //        Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/yakimeshicalofornia-1200x1200px-00377907776449764.png"
            //    },
            //    new CategoriaDto{
            //        Id = "Sopas",
            //        Nombre= "Sopas",
            //        Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/yakimeshicalofornia-1200x1200px-00377907776449764.png"
            //    },
            //    new CategoriaDto{
            //        Id = "Rollos",
            //        Nombre= "Rollos",
            //        Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/yakimeshicalofornia-1200x1200px-00377907776449764.png"
            //    },
            //    new CategoriaDto{
            //        Id = "Gohan",
            //        Nombre= "Gohan",
            //        Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/yakimeshicalofornia-1200x1200px-00377907776449764.png"
            //    }
            //});
        }


    }
}
