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


    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
    }

    public void PrintBooks()
    {
      System.Console.WriteLine("Please choose from the available books:");
      for (int i = 0; i < Books.Count; i++)
      {
        Book currentBook = Books[i];
        Console.WriteLine($"{i + 1} {currentBook.Title} - {currentBook.Author}");
      }
      System.Console.WriteLine("Seleect a book number to checkout (Q)uit, or (R)eturn a book");
    }

    public void PrintCheckedOut()
    {
      System.Console.WriteLine("Books you have checked out.");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Book currentBook = CheckedOut[i];
        Console.WriteLine($"{i + 1} {currentBook.Title} - {currentBook.Author}");
      }
      System.Console.WriteLine("Seleect a book number to return, (Q)uit, or (A)vailable to see available books");
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
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