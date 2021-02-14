using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APBD_egzamin.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
