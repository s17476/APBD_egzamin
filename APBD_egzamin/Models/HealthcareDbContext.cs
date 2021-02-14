using APBD_egzamin.Configurations;
using APBD_egzamin.Extensions;
using Microsoft.EntityFrameworkCore;

namespace APBD_egzamin.Models
{
    public class HealthcareDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


        public HealthcareDbContext()
        {

        }

        public HealthcareDbContext(DbContextOptions options)
        :base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration()); 

            modelBuilder.ApplyConfiguration(new PatientEfConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());

            //initial test data
            modelBuilder.Seed();

        }
    }
}
