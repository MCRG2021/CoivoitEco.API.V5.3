using CovoitEco.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
