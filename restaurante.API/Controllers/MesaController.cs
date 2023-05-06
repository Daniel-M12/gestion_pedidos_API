using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Authorization;
using DBEntity;

namespace restaurante.API.Controllers
{
    [Route("mesas")]
    [Produces("application/json")]
    [ApiController]
    public class MesaController: ControllerBase
	{
		IMesaRepository mesaRepository;

		public MesaController(IMesaRepository mesaRepository)
		{
			this.mesaRepository = mesaRepository;
		}

        [HttpGet]
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult getMesas()
        {
            return Ok(mesaRepository.getMesas());
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        [Route("insert")]
        public IActionResult setCategoria([FromBody] Mesa mesa)
        {
            return Ok(mesaRepository.insert(mesa));
        }
    }
}

