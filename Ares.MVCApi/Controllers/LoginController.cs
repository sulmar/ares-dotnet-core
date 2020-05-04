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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            

            return View(new UserModel());
        }

        [HttpPost]
        public IActionResult Login(
            [FromServices] Domain.Services.IAuthorizationService authorizationService,
            [FromServices] ITokenService tokenService,
            UserModel userModel)
        {
            if (authorizationService.TryAuthorize(userModel.UserId, userModel.Password, out User user))
            {
                var token = tokenService.Create(user);

                return RedirectToAction("Index", "Customers");                

            }
            else
            {
                return BadRequest(new { message = "UserId or password is incorrect" });
            }
        }
    }
}
