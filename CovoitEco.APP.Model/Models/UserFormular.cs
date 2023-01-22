using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class UserFormular
    {
        [Required(ErrorMessage = "Le champ doit être complété")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Doit être uen adresse email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string family_name { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(50, ErrorMessage = "Doit être compris entre 8 et 11 caractères", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",ErrorMessage = "Mot de passe faible (exemple : ALfa_Total_23**")]
        public string password { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string username { get; set; }
    }
}
