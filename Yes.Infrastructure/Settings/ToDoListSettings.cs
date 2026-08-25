using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yes.Domain.Entities;

namespace Yes.Infrastructure.Settings;

public class ToDoListSettings : IEntityTypeConfiguration<ToDoListEntity>
{
    public void Configure(EntityTypeBuilder<ToDoListEntity> builder)
    {
        builder.ToTable("ToDoLists");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasOne(e => e.User)
            .WithMany(e => e.ToDoLists)
            .HasForeignKey(e => e.UserId);
    }
}
