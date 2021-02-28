using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_HospitalDatabase.Data.Models.ModelsConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .Property(x => x.FirstName)
                .IsUnicode(true);

            builder
                .Property(x => x.LastName)
                .IsUnicode(true);

            builder
                .Property(x => x.Address)
                .IsUnicode(true);

            builder
                .Property(x => x.Email)
                .IsUnicode(false);
        }
    }
}
