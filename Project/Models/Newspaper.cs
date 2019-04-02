using console_library.Interfaces;

namespace console_library.Models
{
  public class Newspaper : Publication
  {
    //Properties
    public string PublicationDate { get; set; }

    public Newspaper(string title, string pubDate) : base(title)
    {
      PublicationDate = pubDate;
    }
  }
}