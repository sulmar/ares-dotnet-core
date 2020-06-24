using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.AntiForgeryTokens.TokenAttributes
{
    public class MyValidateAntiforgeryTokenAttribute : AutoValidateAntiforgeryTokenAttribute
    {
        public MyValidateAntiforgeryTokenAttribute()
        {
        }
    }
}
