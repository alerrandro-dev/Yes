using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yes.Domain.Entities;

namespace Yes.Infrastructure.Settings;

internal class TaskSettings : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.Description)
            .HasMaxLength(255);

        builder.HasOne(e => e.ToDoList)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.ToDoListId);
    }
}
