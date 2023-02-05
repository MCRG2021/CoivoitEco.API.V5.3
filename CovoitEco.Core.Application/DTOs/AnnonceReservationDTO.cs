using AutoMapper;
using CovoitEco.Core.Application.Common.Mappings;
using CovoitEco.Core.Application.Models;

namespace CovoitEco.Core.Application.DTOs
{
    public class AnnonceReservationDTO : IMapFrom<AnnonceReservation>
    {
        #region Properties

        public int ANNRES_Id { get; set; }

        #endregion
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnnonceReservation, AnnonceReservationDTO>();
        }
    }
}
