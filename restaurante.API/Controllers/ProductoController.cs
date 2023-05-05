using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Cors;

namespace restaurante.API.Controllers
{
	[Route("productos")]
    [ApiController]
    public class ProductoController: ControllerBase
	{
		IProductoRepository productoRepository;

		public ProductoController(IProductoRepository productoRepository)
		{
			this.productoRepository = productoRepository;
		}

		[HttpGet]
		
		public IActionResult getProductos()
		{
			return Ok(productoRepository.getProductos());
		}
	}
}

