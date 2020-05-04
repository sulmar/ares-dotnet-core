using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ares.MVCApi.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> logger;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerRepository customerRepository)
        {
            this.logger = logger;
            this.customerRepository = customerRepository;
        }
        
       
        public IActionResult Index()
        {

            //if (!this.User.Identity.IsAuthenticated)
            //{
            //    return BadRequest();
            //}    

            // 
            // select phonenumber from Customers where Id = 1009

            IEnumerable<Customer> customers = customerRepository.Get();

            string? email = this.User.FindFirstValue(ClaimTypes.Email);


            logger.LogInformation($"Received {customers.Count()} customers");

            return View(customers);
        }

        [Authorize]
        public IActionResult Edit([FromServices] IMessageSender messageSender)
        {
            messageSender.Send("Edit!");

            return View();
        }

    }
}
