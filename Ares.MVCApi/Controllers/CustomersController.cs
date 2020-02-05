using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.MVCApi.Controllers
{
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
            IEnumerable<Customer> customers = customerRepository.Get();

            logger.LogInformation($"Received {customers.Count()} customers");

            return View(customers);
        }

        public IActionResult Edit([FromServices] IMessageSender messageSender)
        {
            messageSender.Send("Edit!");

            return View();
        }

    }
}
