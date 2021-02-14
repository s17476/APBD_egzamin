using System.Text.Json.Serialization;

namespace APBD_egzamin.Models
{
    public class PrescriptionMedicament
    {
        public int? IdMedicament { get; set; }
        [JsonIgnore]
        public virtual Medicament Medicament { get; set; }
        public int? IdPrescription { get; set; }
        public virtual Prescription Prescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}
