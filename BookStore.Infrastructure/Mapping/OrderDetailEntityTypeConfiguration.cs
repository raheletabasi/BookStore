using BookStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configuration;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetail");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.BookId).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.Qty).IsRequired();
        builder.Property(x => x.Price).IsRequired();

        #region Relations

        builder.HasOne(x => x.Order)
               .WithMany(x => x.OrderDetails)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Book);

        #endregion
    }
}
