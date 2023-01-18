using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        #region Properties

        public int UTL_Id { get; set; }
        public string UTL_Nom { get; set; }
        public string UTL_Prenom { get; set; }
        public bool UTL_Actif { get; set; }
        public string UTL_Mail { get; set; }
        public int UTL_IdAuth0 { get; set; }

        #endregion

        //#region FroeignKey

        //public Role Role { get; set; }

        //#endregion
    }
}
