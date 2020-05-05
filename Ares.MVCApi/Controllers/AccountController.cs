using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.MVCApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ares.MVCApi.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
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

                Response.Cookies.Append("access-token", token);

                return RedirectToAction("Index", "Customers");                

            }
            else
            {
                ModelState.AddModelError("", "UserId or password is incorrect");
                return View();
            }
        }
    }
}
