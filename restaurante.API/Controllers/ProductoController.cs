using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;

namespace restaurante.API.Controllers
{
	[Route("productos")]
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

