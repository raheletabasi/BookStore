using BookStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configuration;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.AuthorId).IsRequired();
        builder.Property(x => x.Publisher).IsRequired();
        builder.Property(x => x.price).IsRequired();
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(x => x.SearchExperssion).HasComputedColumnSql("CONCAT([Name] , '|' , [Authors] , '|' , [Publisher])", stored: true);

        #region Relations

        builder.HasMany(x => x.OrderDetails);
        builder.HasMany(x => x.BookCategories);

        builder.HasOne(x => x.Author)
               .WithMany(x => x.Books)
               .HasForeignKey(x => x.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}
