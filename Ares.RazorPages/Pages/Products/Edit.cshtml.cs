using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Ares.RazorPages.Extensions;

namespace Ares.RazorPages.Pages.Products
{
    public class EditModel : PageModel
    {

        private readonly IProductRepository productRepository;
        private readonly IDistributedCache distributedCache;

        public EditModel(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            this.productRepository = productRepository;
            this.distributedCache = distributedCache;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = distributedCache.Get<Product>($"product-{id}");

            if (Product == null)
            {
                Product = productRepository.Get(id);

                distributedCache.Set<Product>($"product-{id}", Product);
            }

            if (Product == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            distributedCache.Set<Product>($"product-{Product.Id}", Product);

            //productRepository.Update(Product);

            return RedirectToPage("./Details", new { Id = Product.Id });
        }
    }
}