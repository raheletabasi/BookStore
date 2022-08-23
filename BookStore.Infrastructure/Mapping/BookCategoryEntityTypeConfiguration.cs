using BookStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configuration;

public class BookCategoryEntityTypeConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.BookId).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();

        #region Relations

        builder.HasOne(x => x.Category);
        builder.HasOne(x => x.Book);

        #endregion
    }
}
