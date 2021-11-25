using Telluria.Utils.Crud.Entities;

namespace Estudos.BaltaIO.Tarefas.Domain.Entities
{
  public class Book : BaseEntity
  {

    public Book()
    {
    }

    public Book(string isbn, string title, string author, string language, int pages, Guid publisherId, Publisher publisher)
    {
      ISBN = isbn;
      Title = title;
      Author = author;
      Language = language;
      Pages = pages;
      PublisherId = publisherId;
      Publisher = publisher;
    }

    public string? ISBN { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Language { get; set; }
    public int Pages { get; set; }
    public Guid? PublisherId { get; set; }
    public virtual Publisher? Publisher { get; set; }
  }
}
