using Estudos.BaltaIO.Tarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telluria.Utils.Crud.Mapping;

namespace Estudos.BaltaIO.Tarefas.Data.Mappings
{
  public class PublisherMap : BaseEntityMap<Publisher>
  {
    public override void Configure(EntityTypeBuilder<Publisher> builder)
    {
      base.Configure(builder);

      builder.ToTable("reg_publishers");

      builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();

      builder.HasMany(p => p.Books).WithOne(b => b.Publisher).HasForeignKey(b => b.PublisherId);
    }
  }
}
