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
    public class FactureReservationDTO : IMapFrom<FactureReservation>
    {
        #region Properties

        public int FACT_Id { get; set; }

        #endregion
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FactureReservation, FactureReservationDTO>();
        }
    }
}
