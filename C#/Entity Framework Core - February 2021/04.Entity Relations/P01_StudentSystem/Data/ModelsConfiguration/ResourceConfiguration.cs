using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelsConfiguration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                .Property(x => x.Name)
                .IsUnicode();

            builder
                .Property(x => x.Url)
                .IsUnicode(false);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.Resources)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
