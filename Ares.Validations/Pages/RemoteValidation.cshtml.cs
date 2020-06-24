using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ares.Validations.IServices;
using Ares.Validations.ValidationAttributes;
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


        [EmailAddress]
        [PageRemote(
            PageHandler = "CheckEmail",
            HttpMethod = "post",
            ErrorMessage = "Duplicate Email Address",
            AdditionalFields = "__RequestVerificationToken"
            )]
        [BindProperty]
        public string Email { get; set; }

        [PageRemote(
          PageHandler = "CheckPhoneNumber",
          HttpMethod = "post",
          ErrorMessage = "Duplicate Phone Number",
          AdditionalFields = "__RequestVerificationToken"
          )]
        [MyValidation]
        [BindProperty]
        public string PhoneNumber { get; set; }

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

        public JsonResult OnPostCheckPhoneNumber()
        {

            var valid = PhoneNumber.StartsWith("555");
            return new JsonResult(valid);
        }


    }
}