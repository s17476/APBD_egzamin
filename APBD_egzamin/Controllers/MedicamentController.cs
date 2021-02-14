using APBD_egzamin.Models;
using APBD_egzamin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_egzamin.Controllers
{
    [Route("api/medicaments")]
    [ApiController]
    public class MedicamentController : ControllerBase
    {
        private readonly IHealthDbService _db;

        public MedicamentController(IHealthDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetMedicament()
        {
            return Ok(_db.GetMedicament());
        }

        [HttpGet("{id}")]
        public IActionResult GetMedicament(int id)
        {
            return Ok(_db.GetMedicament(id));
        }
    }
}
