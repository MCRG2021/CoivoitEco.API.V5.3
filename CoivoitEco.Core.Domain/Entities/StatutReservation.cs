using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("StatutReservation")]
    public class StatutReservation
    {
        #region Properties

        public int STATRES_Id { get; set; }
        public string STATRES_Libelle { get; set; }

        #endregion
    }
}
