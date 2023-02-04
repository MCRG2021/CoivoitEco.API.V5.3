﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.Filter;
using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CovoitEco.Core.Application.Services.Annonce.Commands
{
    public class CreateAnnonceCommand : IRequest<int>
    {
        #region Properties

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

        #endregion
    }

    public class CreateAnnonceCommandHandler : IRequestHandler<CreateAnnonceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAnnonceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnnonceCommand request, CancellationToken cancellationToken)
        {
            // Check identity user
            var user = await _context.Utilisateur.FindAsync(request.ANN_UTL_Id);
            if (user.UTL_Mail != EmailAuthorizationCheck.email) throw new Exception("Bad user");

            var entity = new Domain.Entities.Annonce()
            {
                ANN_Id = 0,
                ANN_DatePublication = DateTime.Now,
                ANN_Prix = CalculPrixParPersonne(request.ANN_DateDepart, request.ANN_DateArrive),
                ANN_LocaliteDepart = request.ANN_RueDepart + ", " + request.ANN_NumeroDepart + ", " + FirstLetterUpper(request.ANN_VilleDepart) + ", " + request.ANN_CodePostalDepart,
                ANN_LocaliteArrive = request.ANN_RueArrive + ", " + request.ANN_NumeroArrive + ", " + FirstLetterUpper(request.ANN_VilleArrive) + ", " + request.ANN_CodePostalArrive,
                ANN_DateDepart = request.ANN_DateDepart,
                ANN_DateArrive = request.ANN_DateArrive,
                ANN_OptAutoroute = request.ANN_OptAutoroute,
                ANN_OptFumeur = request.ANN_OptFumeur,
                ANN_OptAnimaux = request.ANN_OptAnimaux,
                ANN_VEH_Id = request.ANN_VEH_Id, // veh current 
                ANN_STATANN_Id = 1, // by default in the DB
                ANN_UTL_Id = request.ANN_UTL_Id // user current 
            };

            _context.Annonce.Add(entity);

            // Test minimum 1hours between each annonce
            var annonce = _context.Annonce.Where(item => item.ANN_UTL_Id == request.ANN_UTL_Id);
            foreach (var item in annonce)
            {
                
            }


            await _context.SaveChangesAsync(cancellationToken);

            return entity.ANN_Id;

        }
        private float CalculPrixParPersonne(DateTime departureDate, DateTime arrivalDate) // test => move to create command
        {
            double minutes = 0;
            TimeSpan timespan = arrivalDate - departureDate;
            minutes = timespan.TotalMinutes;
            return (float)Math.Round((minutes * 0.05), 2);
        }

        /// <summary>
        /// Must be a uppercase for annonceRecherche
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string FirstLetterUpper(string word)
        {
            if (word.Length == 0)
                return "";
            else if (word.Length == 1)
                return char.ToUpper(word[0]).ToString();
            else
                 return char.ToUpper(word[0]) + word.Substring(1);
        }

        private bool Overlap(Domain.Entities.Annonce annonceOld, Domain.Entities.Annonce annonceNew)
        {
            double minutes = 0;

            if (annonceOld.ANN_DateDepart > annonceNew.ANN_DateDepart && annonceOld.ANN_DateArrive > annonceNew.ANN_DateArrive)
            {
                TimeSpan timespan = annonceOld.ANN_DateDepart - annonceNew.ANN_DateArrive;
                minutes = timespan.TotalMinutes;
                if (minutes > 60) return false;
            }

            if (annonceOld.ANN_DateDepart < annonceNew.ANN_DateDepart && annonceOld.ANN_DateArrive < annonceNew.ANN_DateDepart)
            {
                TimeSpan timespan = annonceNew.ANN_DateDepart - annonceNew.ANN_DateArrive;
                minutes = timespan.TotalMinutes;
                if (minutes > 60) return false;
            }
            return true;
        }
    }
}