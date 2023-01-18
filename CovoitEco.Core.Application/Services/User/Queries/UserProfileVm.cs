using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.DTOs;

namespace CovoitEco.Core.Application.Services.User.Queries
{
    public class UserProfileVm
    {
        public IList<UserProfileDTO> Lists { get; set; }
    }
}
