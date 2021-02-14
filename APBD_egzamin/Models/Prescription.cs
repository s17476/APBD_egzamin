using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APBD_egzamin.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        [JsonIgnore]
        public int? IdPatient { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        public int? IdDoctor { get; set; }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}
