using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Domain.Entities;

namespace CovoitEco.Core.Application.ExtensionMethods
{
    public static class OverlapControler
    {
        public static List<Annonce> OverlapReservation(Annonce annonceReservation, List<Annonce> allAnnonceList)
        {
            List<Annonce> annonceOverlapList = new List<Annonce>();
            foreach (var annonceList in allAnnonceList)
            {
                if (Overlap(annonceList, annonceReservation)) annonceOverlapList.Add(annonceList);
            }
            return annonceOverlapList;
        }


        // 30 minutes between a reservation 
        private static bool Overlap(Domain.Entities.Annonce annonceOld, Domain.Entities.Annonce annonceNew)
        {
            double minutes = 0;

            if (annonceOld.ANN_DateDepart > annonceNew.ANN_DateDepart && annonceOld.ANN_DateArrive > annonceNew.ANN_DateArrive)
            {
                TimeSpan timespan = annonceOld.ANN_DateDepart - annonceNew.ANN_DateArrive;
                minutes = timespan.TotalMinutes;
                if (minutes > 30) return false;
            }

            if (annonceOld.ANN_DateDepart < annonceNew.ANN_DateDepart && annonceOld.ANN_DateArrive < annonceNew.ANN_DateDepart)
            {
                TimeSpan timespan = annonceNew.ANN_DateDepart - annonceOld.ANN_DateArrive;
                minutes = timespan.TotalMinutes;
                if (minutes > 30) return false;
            }
            return true;
        }
    }
}
