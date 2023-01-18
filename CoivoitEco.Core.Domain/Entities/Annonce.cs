using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Domain.Entities
{
    [Table("Annonce")]
    public class Annonce
    {
        #region Properties

        public int ANN_Id { get; set; }
        public DateTime ANN_DatePublication { get; set; }
        public float ANN_Prix { get; set; }
        public string ANN_LocaliteDepart { get; set; }
        public string ANN_LocaliteArrive { get; set; }
        public DateTime ANN_DateDepart { get; set; }
        public DateTime ANN_DateArrive { get; set; }
        public bool ANN_OptAutoroute { get; set; }
        public bool ANN_OptFumeur { get; set; }
        public bool ANN_OptAnimaux { get; set; }
        public int ANN_VEH_Id { get; set; }
        public int ANN_STATANN_Id { get; set; }
        public int ANN_UTL_Id { get; set; }


        #endregion

        //#region ForiegnKey

        //public Vehicule Vehicule { get; set; }
        //public StatutAnnonce StatutAnnonce { get; set; }
        //public Utilisateur Utilisateur { get; set; }

        //#endregion
    }
}
