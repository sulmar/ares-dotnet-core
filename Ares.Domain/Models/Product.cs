using System;
using System.Text;

namespace Ares.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal  UnitPrice { get; set; }
        public DateTime LastAccess { get; set; }
    }


}
