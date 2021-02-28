using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_HospitalDatabase.Data.Models.ModelsConfigurations
{
    public class PatientMedicamentConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
            builder
                .HasKey(x => new { x.PatientId, x.MedicamentId });

            builder
                .HasOne(x => x.Medicament)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Patient)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
