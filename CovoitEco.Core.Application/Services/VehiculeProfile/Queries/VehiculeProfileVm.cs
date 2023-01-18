using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.DTOs;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Queries
{
    public class VehiculeProfileVm
    {
        public IList<VehiculeProfileDTO> Lists { get; set; }
    }
}
