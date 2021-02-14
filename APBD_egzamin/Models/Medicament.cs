using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APBD_egzamin.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Type { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}
