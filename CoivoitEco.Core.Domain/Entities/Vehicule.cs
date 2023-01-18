using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Vehicule")]
    public class Vehicule
    {
        #region Properties

        public int VEH_Id { get; set; }
        public string VEH_Immatriculation { get; set; }
        public string VEH_Couleur { get; set; }
        public bool VEH_Courant { get; set; }
        public bool VEH_Disponible { get; set; }
        public string VEH_Marque { get; set; }
        public string VEH_Modele { get; set; }
        public int VEH_NombrePlace { get; set; }
        public int VEH_NormeEuro { get; set; }
        public int VEH_UTL_Id { get; set; }


        #endregion

        //#region FroeignKey

        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
