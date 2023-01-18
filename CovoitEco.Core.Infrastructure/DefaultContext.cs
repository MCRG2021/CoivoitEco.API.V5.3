using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Infrastructure
{
    public class DefaultContext : DbContext, IApplicationDbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) // add DefaultContext 
        {
        }

        public DefaultContext() : base()
        {
        }

        #region Properties
        public DbSet<Annonce> Annonce { get; set; }
        public DbSet<Facture> Facture { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Recherche> Recherche { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<StatutAnnonce> StatutAnnonce { get; set; }
        public DbSet<StatutReservation> StatutReservation { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Vehicule> Vehicule { get; set; }

        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
