using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class VehiculeProfileFormular
    {
        #region Properties

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(20, ErrorMessage = "Text trop long.")]
        public string VEH_Immatriculation { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string VEH_Couleur { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string VEH_Marque { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string VEH_Modele { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        public int VEH_NombrePlace { get; set; } 

        [Required(ErrorMessage = "Le champ doit être complété")]
        public int VEH_NormeEuro { get; set; } 
        public int VEH_UTL_Id { get; set; }

        #endregion
    }
}
