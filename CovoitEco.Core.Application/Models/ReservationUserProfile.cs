using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.Core.Application.Models
{
    public class ReservationUserProfile
    {
        #region Properties

        public int RES_Id { get; set; }
        public DateTime RES_DateReservation { get; set; }
        public int RES_ANN_Id { get; set; }
        public string RES_FACT_StatutLibelle { get; set; }
        public bool RES_FACT_FactureResolus { get; set; }
        public float RES_ANN_Prix { get; set; }
        public string RES_ANN_LocaliteDepart { get; set; }
        public string RES_ANN_LocaliteArrive { get; set; }
        public DateTime RES_ANN_DateDepart { get; set; }
        public DateTime RES_ANN_DateArrive { get; set; }
        public string RES_ANN_StatutLibelle { get; set; }
        public bool RES_ANN_OptAutoroute { get; set; }
        public bool RES_ANN_OptFumeur { get; set; }
        public bool RES_ANN_OptAnimaux { get; set; }
        public string RES_ANN_AnnonceurNom { get; set; }
        public string RES_ANN_AnnonceurPrenom { get; set; }
        public string RES_ANN_VEH_VehImmatriculation { get; set; }

        #endregion
    }
}
