﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Validations.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ares.Validations.Pages
{
    public class RemoteValidationModel : PageModel
    {
        private readonly ICustomerService customerService;

        public RemoteValidationModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

       
        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        public JsonResult OnPostCheckEmail()
        {
            var valid = !customerService.ExistsEmail(Email);
            return new JsonResult(valid);
        }


    }
}