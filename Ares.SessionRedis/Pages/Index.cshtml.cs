using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.SessionRedis.Extensions;
using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Ares.SessionRedis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Name { get; private set; }
        public int Score { get; private set; }
        public DateTime Time { get; private set; }

        public const string SessionKeyName = "Name";
        public const string SessionKeyScore = "Score";
        public const string SessionKeyTime = "Time";


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        } 

        public void OnGet()
        {
            //Name = "Player1";
            //Score = 100;
            //Time = DateTime.Now;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Player1");
                HttpContext.Session.SetInt32(SessionKeyScore, 100);
                HttpContext.Session.SetJson<DateTime>(SessionKeyTime, DateTime.Now);
            }

            Name = HttpContext.Session.GetString(SessionKeyName);
            Score = HttpContext.Session.GetInt32(SessionKeyScore).Value;
            Time = HttpContext.Session.GetJson<DateTime>(SessionKeyTime);

                    
        }

    
    }
}
