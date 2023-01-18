using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("StatutAnnonce")]
    public class StatutAnnonce
    {
        #region Properties

        public int STATANN_Id { get; set; }
        public string STATANN_Libelle { get; set; }

        #endregion
    }
}
