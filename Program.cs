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
      Book Harry = new Book("Harry Potter", "JK Rowling");
      Newspaper NYT = new Newspaper("The New York Times", "April 2, 2019");
      Newspaper IS = new Newspaper("The Idaho Statesman", "April 2, 2019");
      Newspaper WP = new Newspaper("The Washington Post", "April 2, 2019");
      Magazine Time = new Magazine("TIME", "March 24, 2019");
      Magazine People = new Magazine("PEOPLE", "March 16, 2019");
      Magazine Highlights = new Magazine("Highlights", "March 29, 2019");


      myLibrary.AddBook(WTSW);
      myLibrary.AddBook(Cat);
      myLibrary.AddBook(Ring);
      System.Console.WriteLine("Welcome to the Library!");

      Enum activeMenu = Menus.Welcome;
      bool inLibrary = true;
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.Welcome:
            System.Console.WriteLine(@"Would you like to view (P)ublications, (V)ideos, (S)ports Equipment
                          OR
(R)eturn an item?");
            WelcomeCommands();
            break;
          case Menus.Publication:
            myLibrary.PrintPublications();
            PublicationCommands();
            break;
          case Menus.Newspaper:
            System.Console.WriteLine("Here are the Newspapers and Magazines we have on hand. Feel free to read whatever you like.");
            myLibrary.PrintPapers();
            myLibrary.PrintMagazines();

            PublicationCommands();
            break;
          // case Menus.Sport:
          //   myLibrary.PrintBooks();
          //   break;
          // case Menus.Video:
          //   myLibrary.PrintBooks();
          //   break;
          case Menus.CheckoutBook:
            myLibrary.PrintBooks();
            BookCommands();
            break;
          case Menus.ReturnBook:
            myLibrary.PrintCheckedOut();
            BookCommands();
            break;
        }

        void WelcomeCommands()
        {
          string input = Console.ReadLine();
          switch (input.ToUpper()[0])
          {
            case 'P':
              activeMenu = Menus.Publication;
              Console.Clear();
              break;
            case 'V':
              activeMenu = Menus.ReturnBook;
              Console.Clear();
              return;
            case 'S':
              activeMenu = Menus.CheckoutBook;
              Console.Clear();
              return;
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

        void PublicationCommands()
        {
          string input = Console.ReadLine();
          switch (input.ToUpper()[0])
          {
            case 'N':
              activeMenu = Menus.Newspaper;
              Console.Clear();
              break;
            case 'M':
              activeMenu = Menus.ReturnBook;
              Console.Clear();
              return;
            case 'B':
              activeMenu = Menus.CheckoutBook;
              Console.Clear();
              return;
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

        void BookCommands()
        {
          string input = Console.ReadLine();
          switch (input.ToUpper()[0])
          {
            case 'Q':
              inLibrary = false;
              break;
            case 'R':
              activeMenu = Menus.ReturnBook;
              Console.Clear();
              return;
            case 'A':
              activeMenu = Menus.CheckoutBook;
              Console.Clear();
              return;
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

      }
      System.Console.WriteLine("Have a great day!");
    }


    public enum Menus
    {
      Welcome,
      CheckoutBook,
      ReturnBook,

      Publication,

      Newspaper,

      Video,

      Sport
    }
  }
}
