using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class CampingCar
    {
        #region Properties

        public int CampingCarId { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public bool Available { get; set; }

        #endregion
    }
    public class CampingCars
    {
        public List<CampingCar> Lists { get; set; }
    }
}
