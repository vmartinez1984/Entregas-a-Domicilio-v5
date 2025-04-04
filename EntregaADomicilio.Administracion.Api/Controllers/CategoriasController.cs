﻿using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomiclio.Administracion.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : BaseEADController
    {
        public CategoriasController(UnitOfWork repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Obtener la lista de categorias
        /// </summary>
        /// <response code="200">List<CategoriaDto>></response>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() => Ok(await _reglasDeNegocio.Categoria.ObtenerTodosAsync());

        /// <summary>
        /// Obtener categoria por id
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <response code="404">No encontrado</response>
        /// <response code="200">CategoriaDto</response>
        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> ObtenerPorId(string categoriaId)
        {
            CategoriaDto categoria;

            categoria = await _reglasDeNegocio.Categoria.ObtenerPorIdAsync(categoriaId);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        /// <summary>
        /// Agregar categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AgregarAsync(CategoriaDtoIn categoria)
        {
            CategoriaDto categoriaDto;

            categoriaDto = await _reglasDeNegocio.Categoria.ObtenerPorIdAsync(categoria.EncodedKey);
            if (categoriaDto != null)
                return Ok(categoriaDto);

            IdDto id;

            id = await _reglasDeNegocio.Categoria.AgregarAsync(categoria);

            return Created($"Categorias/{id.Id}", id);
        }

        /// <summary>
        /// Obtiene la imagen de la categoria por id
        /// </summary>
        /// <param name="categoriaId"></param>        
        [HttpGet("{categoriaId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorIdAsync(string categoriaId)
        {
            byte[] bytes;

            bytes = await _reglasDeNegocio.Categoria.ObtenerImagenPorIdAsync(categoriaId);

            return File(bytes, "image/png");
        }

        [HttpPut("{categoriaId}")]
        public async Task<IActionResult> ActualizarAsync(string categoriaId, CategoriaDtoUpd categoriaDtoIn)
        {
            CategoriaDto categoria;

            categoria = await _reglasDeNegocio.Categoria.ObtenerPorIdAsync(categoriaId);
            if (categoria == null)
                return NotFound();

            await _reglasDeNegocio.Categoria.ActualizarAsync(categoriaId, categoriaDtoIn);

            return Accepted();
        }
    }
}
