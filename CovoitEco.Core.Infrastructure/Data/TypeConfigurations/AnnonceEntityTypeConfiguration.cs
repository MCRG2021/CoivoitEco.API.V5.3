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
    public class AnnonceEntityTypeConfiguration : IEntityTypeConfiguration<Annonce>
    {
        public void Configure(EntityTypeBuilder<Annonce> builder)
        {
            builder.ToTable("Annonce");

            builder.HasKey(item => item.ANN_Id);

            //builder.HasOne(item => item.StatutAnnonce);
            //builder.HasOne(item => item.Vehicule);
            //builder.HasOne(item => item.Utilisateur);
        }
    }
}
