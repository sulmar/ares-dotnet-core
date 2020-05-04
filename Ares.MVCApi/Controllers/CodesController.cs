using Ares.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ares.MVCApi.Controllers
{
    [Route("api/code")]
    public class CodesController : Controller
    {
        //   http://localhost/api/code/customers/10

        // [HttpGet("{handler}/{id?}")]
        //[AcceptVerbs("GET", "POST", Route = "{handler}/{id?}")]
        //public IActionResult Get(string handler, int? id, [FromBody] dynamic item)
        //{
        //    dynamic model = new Customer { FirstName = "Marcin" };

        //    return Ok(model);
        //}


        [HttpGet("{handler}/{id?}")]
        public IActionResult Get(string handler, int? id)
        {
            dynamic model = new Customer { FirstName = "Marcin" };

            return Ok(model);
        }

        [HttpPost("{handler}/{id?}")]
        public IActionResult Post(string handler, int? id, [FromBody] dynamic item)
        {
            dynamic model = new Customer { FirstName = "Marcin" };

            return Ok(model);
        }


     
    }
}
