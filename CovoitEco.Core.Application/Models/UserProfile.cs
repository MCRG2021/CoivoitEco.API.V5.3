using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Application.Models
{
    public class UserProfile
    {
        #region Properties

        public int UTL_Id { get; set; }
        public string UTL_Nom { get; set; }
        public string UTL_Prenom { get; set; }
        public bool UTL_Actif { get; set; }
        public string UTL_Mail { get; set; }
        public int UTL_Auth0 { get; set; }

        #endregion
    }
}
