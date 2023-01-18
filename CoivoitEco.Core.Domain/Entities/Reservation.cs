using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Reservation")]
    public class Reservation
    {
        #region Properties

        public int RES_Id { get; set; }
        public DateTime RES_DateReservation { get; set; }
        public int RES_ANN_Id { get; set; }
        public int RES_STATRES_Id { get; set; }
        public int RES_UTL_Id { get; set; }

        #endregion

        //#region ForeignKey

        //public Annonce Annonce { get; set; }
        //public StatutReservation StatutReservation { get; set; }
        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
