using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Models
{
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLocked { get; set; }
        public Address HomeAddress { get; set; }
    }

    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }

    public class UserRoles
    {
        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
