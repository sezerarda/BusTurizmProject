using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? IdentityNumber { get; set; }
        public Gender Gender { get; set; }


        //public DateTime BirthDate { get; set; }
        //public int Age { get; set; }
        //public string Address { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
    }
}
