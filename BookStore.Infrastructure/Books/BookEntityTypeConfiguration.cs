using BookStore.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Books;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Authors).IsRequired();
        builder.Property(x => x.Publisher).IsRequired();
        builder.Property(x => x.price).IsRequired();
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(x => x.SearchExperssion).HasComputedColumnSql("CONCAT([Name] , '|' , [Authors] , '|' , [Publisher])",stored:true);

        #region Relations

        builder.HasMany(x => x.OrderDetails);
        builder.HasMany(x => x.BookCategories);

        #endregion
    }
}
