using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.DTOs;

namespace CovoitEco.Core.Application.Services.Annonce.Queries
{
    public class AnnonceProfileVm
    {
        public IList<AnnonceProfileDTO> Lists { get; set; }
    }
}
