using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;

namespace restaurante.API.Controllers
{
    [Route("pedidos")]
    public class PedidoController: ControllerBase
	{
		IPedidoRepository pedidoRepository;

		public PedidoController(IPedidoRepository pedidoRepository)
		{
			this.pedidoRepository = pedidoRepository;
		}

        [HttpGet]
        public IActionResult getPedidos()
        {
            return Ok(pedidoRepository.getPedidos());
        }
    }
}

