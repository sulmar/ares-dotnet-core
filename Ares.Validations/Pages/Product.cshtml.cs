using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ares.Validations.Pages
{
    public class ProductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = new Product();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to db
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}