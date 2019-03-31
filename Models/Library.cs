using System;
using System.Collections.Generic;

namespace console_library.Models
{
  class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }


    public void

    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
      }
    }
    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
    }

  }
}