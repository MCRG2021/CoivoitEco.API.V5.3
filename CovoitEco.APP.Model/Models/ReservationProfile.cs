namespace CovoitEco.APP.Model.Models
{
    public class ReservationProfile
    {
        #region Properties

        public int RESPR_Id { get; set; }
        public DateTime RESPR_DateReservation { get; set; }
        public int RESPR_ANN_Id { get; set; }
        public string RESPR_StatutLibelle { get; set; }
        public bool RESPR_FactureResolus { get; set; }
        public string RESPR_Nom { get; set; }
        public string RESPR_Prenom { get; set; }

        #endregion
    }

    public class ReservationProfileVm
    {
        public List<ReservationProfile> Lists { get; set; }
    }
}
