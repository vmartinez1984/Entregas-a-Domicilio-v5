using EntregasADomicilio.Web.Dtos;
using EntregasADomicilio.Web.Mvc.Models;
using EntregasADomicilio.Web.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntregasADomicilio.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string categoriaId = null)
        {
            List<ProductoDto> productos;
            List<CategoriaDto> categorias;
            CategoriaDto categoria;

            ViewBag.Categorias = categorias = await unitOfWork.Categoria.ObtenerAsync();
            categoria = categorias.FirstOrDefault(x => x.Id == categoriaId);
            if (categoria == null)
                productos = await unitOfWork.Producto.ObtenerAsync();
            else
                productos = await unitOfWork.Producto.ObtenerAsync(categoria.Nombre);

            return View(productos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("Producto/{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(string platilloId)
        {
            byte[] bytes;

            bytes = await unitOfWork.Producto.ObtenerImagenPorIdAsync(platilloId);

            return File(bytes, "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
