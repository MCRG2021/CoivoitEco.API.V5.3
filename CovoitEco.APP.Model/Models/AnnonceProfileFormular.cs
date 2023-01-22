using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class AnnonceProfileFormular
    {
        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string ANN_VilleDepart { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string ANN_RueDepart { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(3, ErrorMessage = "Text trop long.")]
        public string ANN_NumeroDepart { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(6, ErrorMessage = "Text trop long.")]
        public string ANN_CodePostalDepart { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string ANN_VilleArrive { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(15, ErrorMessage = "Text trop long.")]
        public string ANN_RueArrive { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(3, ErrorMessage = "Text trop long.")]
        public string ANN_NumeroArrive { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [StringLength(6, ErrorMessage = "Text trop long.")]
        public string ANN_CodePostalArrive { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [Display(Name = "Start Date")]
        [FromNow]
        public DateTime ANN_DateDepart { get; set; }

        [Required(ErrorMessage = "Le champ doit être complété")]
        [Display(Name = "End Date")]
        [StartEndDateValidator]
        public DateTime ANN_DateArrive { get; set; }

        public bool ANN_OptAutoroute { get; set; }
        public bool ANN_OptFumeur { get; set; }
        public bool ANN_OptAnimaux { get; set; }
        public int ANN_VEH_Id { get; set; }
        public int ANN_UTL_Id { get; set; }
    }

    public class FromNowAttribute : ValidationAttribute
    {
        public FromNowAttribute() { }

        public string GetErrorMessage() => "La date doit être suppérieur d'au moins 30min à la date actuelle ";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (date < DateTime.Now + TimeSpan.FromMinutes(30)) return new ValidationResult(GetErrorMessage()); // minimum 15 min to register
            else return ValidationResult.Success;
        }
    }

    public class StartEndDateValidator : ValidationAttribute
    {
        protected override ValidationResult
            IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.AnnonceProfileFormular)validationContext.ObjectInstance;
            DateTime EndDate = Convert.ToDateTime(value);
            DateTime StartDate = Convert.ToDateTime(model.ANN_DateDepart) + TimeSpan.FromMinutes(30); // minimum duration => minimum 30 min

            if (StartDate > EndDate)
            {
                return new ValidationResult
                    ("Trajet trop court");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
