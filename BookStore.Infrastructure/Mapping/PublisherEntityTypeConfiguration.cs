using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Mapping;

public class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publisher");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired();

        #region Relations

        builder.HasMany(x => x.Books);

        #endregion
    }
}
