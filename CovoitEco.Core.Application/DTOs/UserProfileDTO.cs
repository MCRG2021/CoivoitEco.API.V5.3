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
    public class UserProfileDTO : IMapFrom<UserProfile>
    {
        #region Properties

        public int UTL_Id { get; set; }
        public string UTL_Nom { get; set; }
        public string UTL_Prenom { get; set; }
        public bool UTL_Actif { get; set; }
        public string UTL_Mail { get; set; }
        public int UTL_IdAuth0 { get; set; }

        #endregion
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileDTO>();
        }
    }
}
