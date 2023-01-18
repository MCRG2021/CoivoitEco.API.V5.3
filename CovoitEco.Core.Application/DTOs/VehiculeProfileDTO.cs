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
    public class VehiculeProfileDTO : IMapFrom<VehiculeProfile>
    {
        #region Propeties

        public int VEHPR_Id { get; set; }
        public string VEHPR_Immatriculation { get; set; }
        public string VEHPR_Couleur { get; set; }
        public string VEHPR_Marque { get; set; }
        public string VEHPR_Modele { get; set; }
        public int VEHPR_NombrePlace { get; set; }
        public int VEHPR_NormeEuro { get; set; }

        #endregion

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Models.VehiculeProfile, VehiculeProfileDTO>();
        }
    }
}
