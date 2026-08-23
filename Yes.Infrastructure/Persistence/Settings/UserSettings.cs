using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yes.Domain.Entities;

namespace Yes.Infrastructure.Persistence.Settings;

public class UserSettings : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(16);
    }
}
