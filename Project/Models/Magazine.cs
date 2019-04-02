using console_library.Interfaces;

namespace console_library.Models
{
  public class Magazine : Publication
  {
    //Properties
    public string PublicationDate { get; set; }

    public Magazine(string title, string pubDate) : base(title)
    {
      PublicationDate = pubDate;
    }
  }
}