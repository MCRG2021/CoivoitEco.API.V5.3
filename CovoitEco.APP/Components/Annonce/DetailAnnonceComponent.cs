﻿
namespace CovoitEco.APP.Components.Annonce
{
    public class DetailAnnonceComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseAnnonce = await AnnonceQueries.GetAnnonceProfile(idAnnonce);
            responseGetVehicule = await vehiculeQueries.GetVehicule(idAnnonce);

            // Test if er is already a reservation for this annonce
            responseGetAllReservationUser = await ReservationQueries.GetAllReservationUserProfile(idUser);
            CheckReservation();
        }

        protected async Task GetIdReservation()
        {
            idReservation = await ReservationQueries.GetIdReservationUserProfile(idAnnonce, idUser);
        }

        protected async Task CreateReservation()
        {
            requestReservationFormular.RES_UTL_Id = idUser;
            requestReservationFormular.RES_ANN_Id = idAnnonce;
            await ReservationCommands.CreateReservation(requestReservationFormular);
            await GetIdReservation(); 
            if (!idReservation.Equals(null))
            {
                await FactureCommands.CreateFacture(idReservation);
            }
            else
            {
                throw new Exception("You need a idReservation for create a Facture");
            }
        }

        protected void CheckReservation() 
        {
            confirme = false;
            foreach (var reservation in responseGetAllReservationUser.Lists)
            {
                if(reservation.RES_ANN_Id == idAnnonce) confirme = true;
            }
        }
    }
}
