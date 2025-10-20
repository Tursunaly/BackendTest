using BookStore.BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity> 
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(b => b.Title).IsRequired();
        
        builder.Property(x => x.Description).IsRequired();
        
        builder.Property(x => x.Price).IsRequired();
    }
}