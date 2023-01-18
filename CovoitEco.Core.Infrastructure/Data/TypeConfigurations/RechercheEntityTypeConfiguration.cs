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
    public class RechercheEntityTypeConfiguration : IEntityTypeConfiguration<Recherche>
    {
        public void Configure(EntityTypeBuilder<Recherche> builder)
        {
            builder.ToTable("Recherche");

            builder.HasKey(item => item.RECH_Id);

            //builder.HasOne(item => item.Utilisateur);
        }
    }
}
