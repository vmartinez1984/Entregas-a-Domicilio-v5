﻿using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface ICategoriaRdN
    {
        Task ActualizarAsync(string categoriaId, CategoriaDtoIn categoriaDtoIn);
        Task<IdDto> AgregarAsync(CategoriaDtoIn categoria);
        Task BorrarAsync(string categoriaId);
        Task<bool> ExisteAsync(string categoria);
        Task<CategoriaDto> ObtenerPorIdAsync(string categoriaId);
        Task<List<CategoriaDto>> ObtenerTodosAsync();
    }
}
