using Ares.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ares.MVCApi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products;

            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5011/api/products");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer token");
           
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                products = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Product>>(responseStream);
            }
            else
            {
                products = Array.Empty<Product>();
            }

            return View(products);
        }
    }
}
