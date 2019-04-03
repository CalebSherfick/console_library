using System;
using System.Collections.Generic;

namespace console_library.Models
{
  class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }
    private List<Book> CheckedOut { get; set; }
    private List<Newspaper> Papers { get; set; }
    private List<Magazine> Magazines { get; set; }


    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
      Papers = new List<Newspaper>();
      Magazines = new List<Magazine>();
    }

    public void PrintPublications()
    {
      System.Console.WriteLine(@"Would you like to stay and read a (N)ewspaper/Magazine
             OR
would you like to check out a (B)ook?");
    }

    public void PrintBooks()
    {
      System.Console.WriteLine("Please choose from the available books:");
      System.Console.WriteLine("Select a book number to checkout (Q)uit, or (R)eturn a book");
      for (int i = 0; i < Books.Count; i++)
      {
        Book currentBook = Books[i];
        Console.WriteLine($"{i + 1} {currentBook.Title} - {currentBook.Author}");
      }
    }

    public void PrintCheckedOut()
    {
      System.Console.WriteLine("Books you have checked out.");
      System.Console.WriteLine("Select a book number to return, (Q)uit, or (A)vailable to see available books");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Book currentBook = CheckedOut[i];
        Console.WriteLine($"{i + 1} {currentBook.Title} - {currentBook.Author}");
      }
    }

    public void PrintPapers()
    {
      System.Console.WriteLine("Newspapers:");
      for (int i = 0; i < Papers.Count; i++)
      {
        System.Console.WriteLine("TEST");
        Newspaper currentPaper = Papers[i];
        Console.WriteLine($"{i + 1} {currentPaper.Title} - {currentPaper.PublicationDate}");
      }
      System.Console.WriteLine("");
    }

    public void PrintMagazines()
    {
      System.Console.WriteLine("Magazines:");
      for (int i = 0; i < Magazines.Count; i++)
      {
        Magazine currentMagazine = Magazines[i];
        Console.WriteLine($"{i + 1} {currentMagazine.Title} - {currentMagazine.PublicationDate}");
      }
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void AddPaper(Newspaper paper)
    {
      Papers.Add(paper);
    }
    public void AddMagazine(Magazine magazine)
    {
      Magazines.Add(magazine);
    }


    public void Checkout(string input)
    {
      Book selectedBook = ValidateBook(input, Books);
      if (selectedBook == null)
      {
        Console.Clear();
        Console.WriteLine("INVALID SELEECTION");
        return;
      }
      selectedBook.Available = false;
      CheckedOut.Add(selectedBook);
      Books.Remove(selectedBook);
      Console.Clear();
      System.Console.WriteLine("Don't forget to return it when you're done!");
    }


    public void Return(string input)
    {
      Book selectedBook = ValidateBook(input, CheckedOut);
      if (selectedBook == null)
      {
        Console.Clear();
        Console.WriteLine("INVALID SELEECTION");
        return;
      }
      selectedBook.Available = true;
      Books.Add(selectedBook);
      CheckedOut.Remove(selectedBook);
      Console.Clear();
      System.Console.WriteLine("Thank you for returning the book this time.");
    }

    private Book ValidateBook(string input, List<Book> booksList)
    {
      int bookIndex;
      if (Int32.TryParse(input, out bookIndex) && bookIndex > 0 && bookIndex <= booksList.Count)
      {
        return booksList[bookIndex - 1];
      }
      return null;
    }
  }
}