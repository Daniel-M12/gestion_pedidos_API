using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using DBEntity;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace restaurante.API.Controllers
{
	[Route("categorias")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController: ControllerBase
	{
		ICategoriaRepository categoriaRepository;

		public CategoriaController(ICategoriaRepository categoriaRepository)
		{
			this.categoriaRepository = categoriaRepository;
		}

        [HttpGet]
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult getCategorias()
        {
            return Ok(categoriaRepository.getCategorias());
        }

        
        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        [Route("insert")]
		public IActionResult setCategoria([FromBody] Categoria categoria)
		{
			return Ok(categoriaRepository.insert(categoria));
		}
    }
}

