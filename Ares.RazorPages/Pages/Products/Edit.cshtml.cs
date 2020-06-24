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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using Ares.RazorPages.Hubs;

namespace Ares.RazorPages.Pages.Products
{
    public class Location
    {
        public int Lat { get; set; }
        public int Lng { get; set; }
    }

    public class EditModel : PageModel
    {

        private readonly IProductRepository productRepository;
        private readonly IDistributedCache distributedCache;

        private readonly IHubContext<ProductsHub> hubContext;

        private readonly ILogger<EditModel> logger;

        public EditModel(
            IProductRepository productRepository, 
            IDistributedCache distributedCache, 
            ILogger<EditModel> logger,
            IHubContext<ProductsHub> hubContext
            )
        {
            this.productRepository = productRepository;
            this.distributedCache = distributedCache;
            this.logger = logger;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string param1, [FromQuery] Location location)
        {
            // var param1 = this.Request.Query["param1"];
          
            Product = distributedCache.Get<Product>($"product-{id}");

            await hubContext.Clients.All.SendAsync("ChangedProduct", Product);

            if (Product == null)
            {
                Product = productRepository.Get(id);

                distributedCache.Set<Product>($"product-{id}", Product);

                logger.LogInformation($"Hello {Product.Name}");
            }

            if (Product == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            distributedCache.Set<Product>($"product-{Product.Id}", Product);

            //productRepository.Update(Product);

            TempData["Message"] = $"Product {Product.Name} was changed.";

            await hubContext.Clients.All.SendAsync("ChangedProduct", Product);

            return RedirectToPage("./Details", new { Id = Product.Id });
        }


        public IActionResult OnPostNotificationPreferences(int id)
        {
            TempData["Message"] = "You have turned on email notifications";

            // return Partial("_ImagePartial");

            Product = distributedCache.Get<Product>($"product-{id}");

            // return Partial("_ImagePartial");
            return Page();
        }
    }
}