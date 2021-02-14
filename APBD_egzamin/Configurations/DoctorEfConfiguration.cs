using APBD_egzamin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_egzamin.Configurations
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

            builder.Property(e => e.IdDoctor)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasMany(d => d.Prescriptions)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Doctor_Prescription");
        }
    }
}
