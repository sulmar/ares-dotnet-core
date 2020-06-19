using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ares.SessionRedis.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public Product Product { get; set; }

        public DetailsModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void OnGet(int id)
        {
            Product = productRepository.Get(id);
        }
    }
}