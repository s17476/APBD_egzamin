using APBD_egzamin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_egzamin.Services
{
    public interface IHealthDbService
    {
        public IEnumerable<Medicament> GetMedicament();
        public IEnumerable<Medicament> GetMedicament(int id);

        public bool DeletePatient(int id);
    }
}
