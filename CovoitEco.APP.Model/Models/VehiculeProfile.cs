namespace CovoitEco.APP.Model.Models
{
    public class VehiculeProfile
    {
        #region Properties

        public int VEHPR_Id { get; set; }
        public string VEHPR_Immatriculation { get; set; }
        public string VEHPR_Couleur { get; set; }
        public string VEHPR_Marque { get; set; }
        public string VEHPR_Modele { get; set; }
        public int VEHPR_NombrePlace { get; set; }
        public int VEHPR_NormeEuro { get; set; }

        #endregion
    }
    public class VehiculeProfileVm
    {
        public List<VehiculeProfile> Lists { get; set; }
    }
}
