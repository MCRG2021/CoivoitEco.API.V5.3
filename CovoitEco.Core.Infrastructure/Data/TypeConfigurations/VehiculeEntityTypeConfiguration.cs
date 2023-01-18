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
    public class VehiculeEntityTypeConfiguration : IEntityTypeConfiguration<Vehicule>
    {
        public void Configure(EntityTypeBuilder<Vehicule> builder)
        {
            builder.ToTable("Vehicule");

            builder.HasKey(item => item.VEH_Id);

            //builder.HasOne(item => item.Utilisateur);
        }
    }
}
