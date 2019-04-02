using console_library.Interfaces;

namespace console_library.Models
{
  class Movie : ICheckoutable
  {
    public string Title { get; set; }
    public string RunTime { get; set; }
    public bool Checkoutable { get; set; }
    public bool Available { get; set; }

    public Movie(string title, string runTime)
    {
      Title = title;
      RunTime = runTime;
      Available = true;
    }
  }
}