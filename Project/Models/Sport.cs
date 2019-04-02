using console_library.Interfaces;

namespace console_library.Models
{
  class Sports : ICheckoutable
  {
    public bool Checkoutable { get; set; }
    public bool Available { get; set; }

    public Sports()
    {
      Available = true;
    }
  }
}