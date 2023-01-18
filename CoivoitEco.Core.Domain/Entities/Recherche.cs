using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Recherche")]
    public class Recherche
    {
        #region Properties

        public int RECH_Id { get; set; }
        public DateTime RECH_DateEnregistrement { get; set; }
        public string RECH_LocaliteDepart { get; set; }
        public string RECH_LocaliteArrvie { get; set; }
        public DateTime RECH_HeureDepart { get; set; }
        public int RECH_UTL_Id { get; set; }

        #endregion

        //#region FroeignKey

        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
