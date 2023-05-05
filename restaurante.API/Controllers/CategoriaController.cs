using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using DBEntity;
using System.Web;
using Microsoft.AspNetCore.Cors;

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

		[HttpPost]
		public IActionResult setCategoria([FromBody] Categoria categoria)
		{
			return Ok(categoriaRepository.insert(categoria));
		}
    }
}

