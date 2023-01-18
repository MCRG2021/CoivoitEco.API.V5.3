using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovoitEco.APP.Model.Models
{
    public class AnnonceProfileFormular
    {
        public string ANN_VilleDepart { get; set; }
        public string ANN_RueDepart { get; set; }
        public string ANN_NumeroDepart { get; set; }
        public string ANN_CodePostalDepart { get; set; }
        public string ANN_VilleArrive { get; set; }
        public string ANN_RueArrive { get; set; }
        public string ANN_NumeroArrive { get; set; }
        public string ANN_CodePostalArrive { get; set; }
        public DateTime ANN_DateDepart { get; set; }
        public DateTime ANN_DateArrive { get; set; }
        public bool ANN_OptAutoroute { get; set; }
        public bool ANN_OptFumeur { get; set; }
        public bool ANN_OptAnimaux { get; set; }
        public int ANN_VEH_Id { get; set; }
        public int ANN_UTL_Id { get; set; }
    }
}
