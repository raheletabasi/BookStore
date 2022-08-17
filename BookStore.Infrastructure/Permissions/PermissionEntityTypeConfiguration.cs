using BookStore.Domain.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Permissions;

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
