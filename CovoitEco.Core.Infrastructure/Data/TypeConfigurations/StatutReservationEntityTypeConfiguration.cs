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
    public class StatutReservationEntityTypeConfiguration : IEntityTypeConfiguration<StatutReservation>
    {
        public void Configure(EntityTypeBuilder<StatutReservation> builder)
        {
            builder.ToTable("StatutResevation");

            builder.HasKey(item => item.STATRES_Id);
        }
    }
}
