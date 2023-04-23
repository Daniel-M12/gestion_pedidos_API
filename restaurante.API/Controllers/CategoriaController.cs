using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;

namespace restaurante.API.Controllers
{
	[Route("categorias")]
	public class CategoriaController: ControllerBase
	{
		ICategoriaRepository categoriaRepository;

		public CategoriaController(ICategoriaRepository categoriaRepository)
		{
			this.categoriaRepository = categoriaRepository;
		}

        [HttpGet]
        public IActionResult getCategorias()
        {
            return Ok(categoriaRepository.getCategorias());
        }
    }
}

