using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
