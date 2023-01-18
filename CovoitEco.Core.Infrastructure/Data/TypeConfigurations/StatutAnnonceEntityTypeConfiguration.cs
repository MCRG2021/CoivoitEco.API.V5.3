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
    public class StatutAnnonceEntityTypeConfiguration : IEntityTypeConfiguration<StatutAnnonce>
    {
        public void Configure(EntityTypeBuilder<StatutAnnonce> builder)
        {
            builder.ToTable("StatutAnnonce");

            builder.HasKey(item => item.STATANN_Id);
        }
    }
}
