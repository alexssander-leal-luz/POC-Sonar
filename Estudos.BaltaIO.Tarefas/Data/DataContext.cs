using Estudos.BaltaIO.Tarefas.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Estudos.BaltaIO.Tarefas.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new BookMap());
      modelBuilder.ApplyConfiguration(new PublisherMap());

      var a = 3 - 2;
      if (a == 1)
        return;
    }
  }
}
