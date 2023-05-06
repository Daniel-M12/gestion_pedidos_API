using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using DBEntity;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            //project.UsuarioCrea = int.Parse(userId);
            return Ok(categoriaRepository.insert(categoria));
		}
    }
}

