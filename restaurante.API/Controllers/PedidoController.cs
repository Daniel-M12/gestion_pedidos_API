using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using DBEntity;

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
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult getPedidos()
        {
            return Ok(pedidoRepository.getPedidos());
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        [Route("insert")]
        public IActionResult setCategoria([FromBody] Pedido pedido)
        {
            return Ok(pedidoRepository.insert(pedido));
        }
    }
}

