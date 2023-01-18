using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class VehiculeProfileFormular
    {
        #region Properties

        public string VEH_Immatriculation { get; set; }
        public string VEH_Couleur { get; set; }
        public string VEH_Marque { get; set; }
        public string VEH_Modele { get; set; }
        public int VEH_NombrePlace { get; set; }
        public int VEH_NormeEuro { get; set; }
        public int VEH_UTL_Id { get; set; }

        #endregion
    }
}
