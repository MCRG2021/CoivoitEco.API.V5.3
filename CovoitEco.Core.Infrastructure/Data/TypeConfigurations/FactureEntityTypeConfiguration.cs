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
    public class FactureEntityTypeConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder) 
        {
            builder.ToTable("Facture");

            builder.HasKey(item => item.FACT_Id);

            //builder.HasOne(item => item.Reservation);
        }
    }
}
