using console_library.Interfaces;

namespace console_library.Models
{
  public class Book : Publication, ICheckoutable
  {
    //Properties
    public string Author { get; set; }
    public bool Checkoutable { get; set; }
    public bool Available { get; set; }


    public Book(string title, string author) : base(title)
    {
      Author = author;
      Available = true;

    }
  }
}