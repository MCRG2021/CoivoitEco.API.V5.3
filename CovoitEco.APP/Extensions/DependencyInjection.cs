using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Service.Annonce.Commands;
using CovoitEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Service.Facture.Commands;
using CovoitEco.APP.Service.Facture.Queries;
using CovoitEco.APP.Service.Reservation.Commands;
using CovoitEco.APP.Service.Reservation.Queries;
using CovoitEco.APP.Service.Utilisateur.Commands;
using CovoitEco.APP.Service.Utilisateur.Queries;
using CovoitEco.APP.Service.Vehicule.Commands;
using CovoitEco.APP.Service.Vehicule.Queries;

namespace CovoitEco.APP.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAnnonceQueriesService, AnnonceQueriesService>();
            services.AddScoped<IAnnonceCommandsService, AnnonceCommandsService>();
            services.AddScoped<IVehiculeQueriesService, VehiculeProfileQueries>();
            services.AddScoped<IReservationCommandsService, ReservationCommandsService>();
            services.AddScoped<IReservationQueriesService, ReservationQueriesService>();
            services.AddScoped<IFactureCommandsService, FactureCommandsService>();
            services.AddScoped<IFactureQueriesService, FactureQueriesService>();
            services.AddScoped<IUtilisateurQueriesService, UtilisateurQueriesService>();
            services.AddScoped<IVehiculeCommandsService, VehiculeCommandsService>();
            services.AddScoped<IUtilisateurCommandsService, UtilisateurCommandService>();
            return services;
        }
    }
}
