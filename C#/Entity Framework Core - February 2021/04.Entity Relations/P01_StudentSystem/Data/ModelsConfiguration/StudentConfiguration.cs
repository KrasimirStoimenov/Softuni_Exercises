using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelsConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(x => x.Name)
                .IsUnicode();

            builder
                .Property(x => x.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}
