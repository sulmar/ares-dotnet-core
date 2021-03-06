﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly IDistributedCache distributedCache;

        public Product Product { get; set; }

        public DetailsModel(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            this.productRepository = productRepository;
            this.distributedCache = distributedCache;
        }

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
    }
}