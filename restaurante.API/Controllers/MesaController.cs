using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;

namespace restaurante.API.Controllers
{
    [Route("mesas")]
    public class MesaController: ControllerBase
	{
		IMesaRepository mesaRepository;

		public MesaController(IMesaRepository mesaRepository)
		{
			this.mesaRepository = mesaRepository;
		}

        [HttpGet]
        public IActionResult getMesas()
        {
            return Ok(mesaRepository.getMesas());
        }
    }
}

