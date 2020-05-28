using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ares.RazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            Products = productRepository.Get();
        }
    }
}