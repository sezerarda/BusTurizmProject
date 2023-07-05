using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.SeatNumber).IsRequired().HasColumnType("int");


            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.BusTrip)
             .WithMany()
             .HasForeignKey(x => x.BusTripId)
             .OnDelete(DeleteBehavior.NoAction);


            //Bu olmadı sebebini hocaya sor

            //builder.HasOne<BusTrip>()
            //    .WithMany()
            //    .HasForeignKey(x=>x.BusTripId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Ticket
            {
                Id = 1,
                Price = 200,
                SeatNumber = 1,
                CustomerId = 1,
                BusTripId= 1,
            });
               
        }
    }
}
