using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.MVCApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.MVCApi.Controllers
{
  //  [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = userRepository.Get();

            return View(users);
        }


        [AllowAnonymous]
        [HttpPost("/token/create")]
        public IActionResult CreateToken(
            [FromServices] Domain.Services.IAuthorizationService authorizationService,
            [FromServices] ITokenService tokenService,
            [FromBody] UserModel userModel)
        {
            if (authorizationService.TryAuthorize(userModel.UserId, userModel.Password, out User user))
            {
                var token = tokenService.Create(user);

                return Ok(token);
            }
            else
            {
                return BadRequest(new { message = "UserId or password is incorrect" });
            }
        }
    }
}
