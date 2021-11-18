using Telluria.Utils.Crud.Entities;

namespace Estudos.BaltaIO.Tarefas.Domain.Entities
{
  public class Publisher : BaseEntity
  {
    public Publisher() => Books = new List<Book>();
    public Publisher(string name, ICollection<Book> books)
    {
      Name = name;
      Books = books;
    }

    public string? Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}
