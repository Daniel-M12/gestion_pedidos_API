using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using DBEntity;

namespace restaurante.API.Controllers
{
	[Route("productos")]
    [Produces("application/json")]
    [ApiController]
    public class ProductoController: ControllerBase
	{
		IProductoRepository productoRepository;

		public ProductoController(IProductoRepository productoRepository)
		{
			this.productoRepository = productoRepository;
		}

		[HttpGet]
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult getProductos()
		{
			return Ok(productoRepository.getProductos());
		}

        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        [Route("insert")]
        public IActionResult setCategoria([FromBody] Producto producto)
        {
            return Ok(productoRepository.insert(producto));
        }
    }
}

