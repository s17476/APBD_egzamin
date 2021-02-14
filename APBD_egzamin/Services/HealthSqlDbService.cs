using APBD_egzamin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_egzamin.Services
{
    public class HealthSqlDbService : IHealthDbService
    {
        private readonly HealthcareDbContext _context;
        public HealthSqlDbService(HealthcareDbContext context)
        {
            _context = context;
        }
      

        public IEnumerable<Medicament> GetMedicament()
        {
           return _context.Medicaments.ToList();
        }

        public IEnumerable<Medicament> GetMedicament(int id)
        {



            return _context.Medicaments
                .Where(d => d.IdMedicament == id)
                .Select(m => new Medicament
                {
                    IdMedicament = m.IdMedicament,
                    Name = m.Name,
                    Desciption = m.Desciption,
                    Type = m.Type,
                    PrescriptionMedicaments = m.PrescriptionMedicaments.ToList()
                }).ToList();
            
        }

        public bool DeletePatient(int id)
        {
            Patient patient = _context.Patients.FirstOrDefault(pat => pat.IdPatient == id);

            if (patient != null)
            {
                _context.Attach(patient);
                _context.Remove(patient);

                _context.SaveChanges();

                return true;
            }

            return false;
        }


    }
}
