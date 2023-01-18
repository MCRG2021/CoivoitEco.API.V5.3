using Microsoft.EntityFrameworkCore;

namespace CoivoitEco.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<Booking> Booking { get; set; }
        //public DbSet<CampingCar> CampingCar { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
