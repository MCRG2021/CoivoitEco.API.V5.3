using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Domain.Entities;

namespace CovoitEco.Core.Application.Models
{
    public class AnnonceProfile
    {
        #region Properties

        public int ANNPR_Id { get; set; }
        public DateTime ANNPR_DatePublication { get; set; }
        public float ANNPR_Prix { get; set; }
        public string ANNPR_LocaliteDepart { get; set; }
        public string ANNPR_LocaliteArrive { get; set; }
        public DateTime ANNPR_DateDepart { get; set; }
        public DateTime ANNPR_DateArrive { get; set; }
        public string ANNPR_Statut { get; set; }
        public bool ANN_OptAutoroute { get; set; }
        public bool ANN_OptFumeur { get; set; }
        public bool ANN_OptAnimaux { get; set; }
        public string ANNPR_AnnonceurNom { get; set; }
        public string ANNPR_AnnonceurPrenom { get; set; }
        public string ANNPR_VehImmatriculation { get; set; }

        #endregion
    }
}
