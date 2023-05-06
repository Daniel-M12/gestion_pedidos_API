using System;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using DBEntity;
//using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
//using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Security;

namespace restaurante.API.Controllers
{
    [Route("users")]
	[Produces("application/json")]
	[ApiController]
    public class UserController : ControllerBase
	{
		IUserRepository userRepository;

		public UserController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		[Produces("application/json")]
		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public async Task<ActionResult> Login(EntityLogin login)
		{
			var rest = userRepository.Login(login);

            if (rest.data != null)
            {
                var loginresponse = rest.data as EntityLoginResponse;
                var uid = loginresponse.id_usuario.ToString();
                var udoc = loginresponse.dni;

                var token = JsonConvert.DeserializeObject<AccessToken>(
                                        await new Authentication()
                                        .GenerateToken(udoc, uid)
                                        ).access_token;

                loginresponse.token = token;
                rest.data = loginresponse;

            }

            return Ok(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityUser user)
        {
            var rest = userRepository.Insert(user);
            return Ok(rest);
        }
    }
}

