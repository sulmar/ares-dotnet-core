using System;

namespace Ares.Domain.Models
{

    public class Customer : BaseEntity, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public bool IsRemoved { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString() => FullName;
    }
}
