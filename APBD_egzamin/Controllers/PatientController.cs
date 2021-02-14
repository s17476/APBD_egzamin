using APBD_egzamin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_egzamin.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IHealthDbService _db;

        public DoctorController(IHealthDbService db)
        {
            _db = db;
        }

        [HttpDelete("{id}")]
        public IActionResult Deletepatient(int id)
        {

            var deleted = _db.DeletePatient(id);
            if (deleted) return Ok();

            return BadRequest();
        }
    }
}