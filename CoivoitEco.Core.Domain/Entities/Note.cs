using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Note")]
    public class Note
    {
        #region Properties

        public int NOT_Id { get; set; }
        public float NOT_Cotation { get; set; }
        public int NOT_UTL_Id { get; set; }

        #endregion

        //#region ForeignKey

        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
