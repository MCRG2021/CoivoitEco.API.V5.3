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
        [Required]
        public string email { get; set; }
        [Required]
        public string family_name { get; set; }
        [Required]
        public string password { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "usurname is too long.")]
        public string username { get; set; }
    }
}
