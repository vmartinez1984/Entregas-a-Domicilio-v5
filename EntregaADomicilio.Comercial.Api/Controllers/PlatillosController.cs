﻿using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    /// <summary>
    /// Controlador para platillos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : BaseController
    {
        /// <summary>
        /// Constructor donde inyecta el repo
        /// </summary>
        /// <param name="repositorio"></param>
        public PlatillosController(PedidoUoW repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Obtiene la lista de platillos
        /// </summary>
        /// <response code="200">Lista de platillos</response>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() => Ok(await _reglasDeNegocio.Platillo.ObtenerTodosAsync());

        /// <summary>
        /// Buscar por nombre o ingrediente
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpGet("{nombre}/Buscar")]
        public async Task<IActionResult> Buscar(string nombre)
        {
            PlatilloDto platillo;

            platillo = await _reglasDeNegocio.Platillo.BuscarAsync(nombre);
            if (platillo == null) 
                return NotFound();

            return Ok(platillo);
        }

        /// <summary>
        /// Lista de platillos por categoria
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns></returns>
        [HttpGet("Categorias/{categoriaId}")]
        public async Task<IActionResult> ObtenerPorCategoriaIdAsync(string categoriaId)
        {
            CategoriaDto categoria;

            categoria = await _reglasDeNegocio.Categoria.ObtenerPorIdAsync(categoriaId);
             if(categoria == null)
                return NotFound(new { Mensanje = "No se encontro la categoria" });
            var lista = await _reglasDeNegocio.Platillo.ObtenerPorCategoriaIdAsync(categoria.Nombre);
            foreach (var item in lista)            
                item.EnlaceDeImagen = $"/api/Platillos/{item.Id}/Imagen";           

            return Ok(lista);
        }

        /// <summary>
        /// Platillo por id
        /// </summary>
        /// <param name="platilloId"></param>
        /// <returns></returns>
        [HttpGet("{platilloId}")]
        public async Task<IActionResult> ObtenerPorIdAsync(string platilloId)
        {
            PlatilloDto platillo;

            platillo = await _reglasDeNegocio.Platillo.ObtenerPorIdAsync(platilloId);
            if (platillo == null)
                return NotFound();

            return Ok(platillo);
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(string platilloId)
        {
            byte[] bytes;

            bytes = await _reglasDeNegocio.Platillo.ObtenerImagenPorIdAsync(platilloId);

            return File(bytes, "image/png");
        }
    }
}
