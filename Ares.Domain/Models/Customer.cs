using System;

namespace Ares.Domain.Models
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public bool IsRemoved { get; set; }
    }
}
