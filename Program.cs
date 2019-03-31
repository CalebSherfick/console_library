using System;
using console_library.Models;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      //initialize library
      Library myLibrary = new Library("3742 Library St.", "Caleb's Library");

      //initialize books
      Book WTSW = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book Cat = new Book("Cat in the Hat", "Dr. Seuss");
      Book Ring = new Book("Lord of the Rings", "J.R. Tolkin");
      myLibrary.AddBook(WTSW);
      myLibrary.AddBook(Cat);
      myLibrary.AddBook(Ring);
      System.Console.WriteLine("Welcome to the Library!");

      Enum activeMenu = Menus.CheckoutBook;
      bool inLibrary = true;
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            myLibrary.PrintBooks();
            break;
          case Menus.ReturnBook:
            myLibrary.PrintCheckedOut();
            break;
        }

        string input = Console.ReadLine();
        switch (input.ToUpper()[0])
        {
          case 'Q':
            inLibrary = false;
            break;
          case 'R':
            activeMenu = Menus.ReturnBook;
            Console.Clear();
            break;
          case 'A':
            activeMenu = Menus.CheckoutBook;
            Console.Clear();
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              myLibrary.Checkout(input);
            }
            else
            {
              myLibrary.Return(input);
            }
            break;

        }

      }
      System.Console.WriteLine("Have a great day!");
    }


    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
  }
}
