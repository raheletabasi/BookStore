using BookStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configuration;

public class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Persmission");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired();

        #region Relations

        builder.HasMany(x => x.RolePermissions);
        builder.HasMany(x => x.Permissions);

        #endregion
    }
}
