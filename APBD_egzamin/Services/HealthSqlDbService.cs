using APBD_egzamin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                .Where(d => d.IdMedicament == id).Include(m => m.PrescriptionMedicaments).ToList();
            
        }

        public bool DeletePatient(int id)
        {

            using var transaction = _context.Database.BeginTransaction();

            try
            {

                Patient patient = _context.Patients.Include(p => p.Prescriptions)
                .FirstOrDefault(p => p.IdPatient == id);

                if (patient != null)
                {
                    _context.Attach(patient);

                    foreach (var child in patient.Prescriptions.ToList())
                    {
                        _context.Attach(child);
                         List<PrescriptionMedicament> pm = _context.PrescriptionMedicaments
                            .Where(p => p.IdPrescription == child.IdPrescription)
                            .ToList();

                    foreach(var pcChild in pm) {
                        _context.PrescriptionMedicaments.Attach(pcChild);
                        _context.PrescriptionMedicaments.Remove(pcChild);
                        _context.SaveChanges();
                    }

                        _context.Prescriptions.Remove(child);
                        _context.SaveChanges();
                }
                    
                    _context.Remove(patient);
                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }

                
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
