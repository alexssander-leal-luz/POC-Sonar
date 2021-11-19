using Estudos.BaltaIO.Tarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telluria.Utils.Crud.Mapping;

namespace Estudos.BaltaIO.Tarefas.Data.Mappings
{
  public class BookMap : BaseEntityMap<Book>
  {
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
      base.Configure(builder);

      builder.ToTable("reg_books");

      builder.Property(p => p.ISBN).HasColumnName("isbn").HasColumnType("varchar(100)").IsRequired();
      builder.Property(p => p.Language).HasColumnName("language").HasColumnType("varchar(100)").IsRequired();
      builder.Property(p => p.Author).HasColumnName("author").HasColumnType("varchar(100)").IsRequired();
      builder.Property(p => p.Pages).HasColumnName("pages").HasColumnType("numeric(4,0)").IsRequired();
      builder.Property(p => p.Title).HasColumnName("title").HasColumnType("varchar(100)").IsRequired();
      builder.Property(p => p.PublisherId).HasColumnName("publisher_id");

      // builder.HasOne(p => p.Publisher).WithMany().HasForeignKey(p => p.PublisherId);

      builder.HasIndex(p => p.ISBN).IsUnique();
    }
  }
}
