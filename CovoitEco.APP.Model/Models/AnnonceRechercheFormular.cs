using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class AnnonceRechercheFormular
    {
        #region Properties

        [Required(ErrorMessage = "Le champ doit être complété")]
        public DateTime departureDate { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string departureCity { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string arrivalCity { get; set; }

        #endregion
    }
}
