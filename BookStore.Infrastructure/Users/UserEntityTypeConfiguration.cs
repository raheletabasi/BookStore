using BookStore.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Gender).IsRequired().HasDefaultValue(2);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(1);
        builder.Property(x => x.SearchExperssion).HasComputedColumnSql("CONCAT([UserName],'|',[FirstName],'|',[LastName])", stored: true);

        #region Relations

        builder.HasMany(x => x.UserRoles);

        #endregion
    }
}
