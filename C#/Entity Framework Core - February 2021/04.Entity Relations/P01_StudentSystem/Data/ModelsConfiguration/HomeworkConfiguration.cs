using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelsConfiguration
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .Property(x => x.Content)
                .IsUnicode(false);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.HomeworkSubmissions)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.HomeworkSubmissions)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
