using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Facture")]
    public class Facture
    {
        #region Properties

        public int FACT_Id { get; set; }
        public DateTime FACT_DateCreation { get; set; }
        public DateTime? FACT_DatePayment { get; set; }
        public bool FACT_Resolus { get; set; }
        public int FACT_RES_Id { get; set; }

        #endregion

        //#region FroeignKey

        //public Reservation Reservation { get; set; }

        //#endregion
    }
}
