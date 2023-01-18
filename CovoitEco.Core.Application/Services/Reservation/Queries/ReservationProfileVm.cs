using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.DTOs;

namespace CovoitEco.Core.Application.Services.Reservation.Queries
{
    public class ReservationProfileVm
    {
        public IList<ReservationProfileDTO> Lists { get; set; }
    }
}
