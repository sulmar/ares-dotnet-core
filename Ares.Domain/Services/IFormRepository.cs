using Ares.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Services
{
    public interface IFormRepository
    {
        Form Get(string name);
    }
}
