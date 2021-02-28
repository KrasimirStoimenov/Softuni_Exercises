using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_HospitalDatabase.Data.Models.ModelsConfigurations
{
    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder
                .HasOne(x => x.Patient)
                .WithMany(x => x.Visitations)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Visitations)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
