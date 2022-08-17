using BookStore.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Roles;

public class RoleEntityTypeConfiuration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired();

        #region Relations

        builder.HasMany(x => x.UserRoles);
        builder.HasMany(x => x.RolePermissions);

        #endregion

    }
}
