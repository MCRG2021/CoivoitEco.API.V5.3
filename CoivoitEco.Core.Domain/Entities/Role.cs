using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Role")]
    public class Role
    {
        #region Properties

        public int ROL_Id { get; set; }
        public string ROL_Libelle { get; set; }

        #endregion
    }
}
