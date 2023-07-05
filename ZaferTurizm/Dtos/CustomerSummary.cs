using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class CustomerSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? IdentityNumber { get; set; }
        public Gender Gender { get; set; }
    }
}
