using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ares.Validations.Pages
{
    public class RemoteValidationModel : PageModel
    {
        [PageRemote(
       ErrorMessage = "Duplicate Email Address",
       AdditionalFields = "__RequestVerificationToken",
       HttpMethod = "post",
       PageHandler = "CheckEmail"
   )]
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
            var existingEmails = new[] { "jane@test.com", "claire@test.com", "dave@test.com" };
            var valid = !existingEmails.Contains(Email);
            return new JsonResult(valid);
        }


    }
}