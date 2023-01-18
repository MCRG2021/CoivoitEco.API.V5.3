using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Mappings;
using CovoitEco.Core.Application.Models;

namespace CovoitEco.Core.Application.DTOs
{
    public class ReservationProfileDTO : IMapFrom<ReservationProfile>
    {

        #region Properties

        public int RESPR_Id { get; set; }
        public DateTime RESPR_DateReservation { get; set; }
        public int RESPR_ANN_Id { get; set; }
        public string RESPR_StatutLibelle { get; set; }
        public bool RESPR_FactureResolus { get; set; }
        public string RESPR_Nom { get; set; }
        public string RESPR_Prenom { get; set; }

        #endregion

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Models.ReservationProfile, ReservationProfileDTO>();
        }

    }
   
}
