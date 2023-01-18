using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovoitEco.Core.Infrastructure.Data.TypeConfigurations
{
    public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.HasKey(item => item.RES_Id);

            //builder.HasOne(item => item.Annonce);
            //builder.HasOne(item => item.StatutReservation);
            //builder.HasOne(item => item.Utilisateur);
        }
    }
}
