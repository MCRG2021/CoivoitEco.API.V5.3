using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Notification")]
    public class Notification
    {
        #region Properties

        public int NOTIF_Id { get; set; }
        public string NOTIF_Libelle { get; set; }
        public int ROL_UTL_Id { get; set; }

        #endregion

        //#region FroiegnKey

        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
