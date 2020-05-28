using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ares.Domain.Models
{
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        string initial = FirstName.Substring(0, 1) + LastName.Substring(0, 1);

        //        return $"{initial} {FirstName} {LastName}";
        //    }
        //}

        public string Initial => FirstName.Substring(0, 1) + LastName.Substring(0, 1);
        public string FullName => $"{Initial} {FirstName} {LastName}";


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
