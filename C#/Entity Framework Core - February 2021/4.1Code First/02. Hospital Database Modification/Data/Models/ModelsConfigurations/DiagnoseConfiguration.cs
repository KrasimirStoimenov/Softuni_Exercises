using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_HospitalDatabase.Data.Models.ModelsConfigurations
{
    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder
                .HasOne(x => x.Patient)
                .WithMany(x => x.Diagnoses)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
