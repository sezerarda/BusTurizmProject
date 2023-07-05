using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.Surname).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.IdentityNumber).IsRequired(false).HasColumnType("Varchar(50)");
            builder.Property(x => x.Gender).IsRequired().HasColumnType("int").HasColumnName("Cinsiyet");

            builder.HasData(new Customer()
            {
                Id = 1,
                Name = "Mustafa",
                Surname = "Korkmaz",
                Gender = Gender.Male,
                IdentityNumber = "1234566"
            });
        }
    }
}
