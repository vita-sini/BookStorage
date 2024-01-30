using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp224
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.Work();
        }
    }

    class Storage
    {
        private List<Book> _book = new List<Book>();

        private int _bookId = 0;

        public void Work()
        {
            const string CommandAddBook = "1";
            const string CommandShowBook = "2";
            const string CommandRemoveBook = "3";
            const string CommandShowBooksAuthor = "4";
            const string CommandShowBooksTitle = "5";
            const string CommandShowBooksYearRelease = "6";
            const string CommandEndProgram = "7";

            bool isProgramWork = true;

            while (isProgramWork == true)
            {
                Console.WriteLine($"{CommandAddBook} - Добавить книгу в хранилище.");
                Console.WriteLine($"{CommandShowBook} - Показать все книги.");
                Console.WriteLine($"{CommandRemoveBook} - Убрать книгу.");
                Console.WriteLine($"{CommandShowBooksAuthor} - Показать книги по указанному автору.");
                Console.WriteLine($"{CommandShowBooksTitle} - Показать книги по названию.");
                Console.WriteLine($"{CommandShowBooksYearRelease} - Показать книги по году выпуска.");
                Console.WriteLine($"{CommandEndProgram} - Выход из программы.");
                Console.Write("Твой выбор: ");

                string selectedOperation = Console.ReadLine();

                switch (selectedOperation)
                {
                    case CommandAddBook:
                        AddBook();
                        break;

                    case CommandShowBook:
                        ShowBook();
                        break;

                    case CommandRemoveBook:
                        RemoveBook();
                        break;

                    case CommandShowBooksAuthor:
                        ShowBooksAuthor();
                        break;

                    case CommandShowBooksTitle:
                        ShowBooksTitle();
                        break;

                    case CommandShowBooksYearRelease:
                        ShowBooksYearRelease();
                        break;

                    case CommandEndProgram:
                        isProgramWork = false;
                        break;

                    default:
                        OutputText();
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private bool TryGetBook(out Book book)
        {
            Console.WriteLine("Введите год выпуска: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                for (int i = 0; i < _book.Count; i++)
                {
                    if (number == _book[i].UniqueNumber)
                    {
                        book = _book[i];
                        return true;
                    }
                }
            }

            book = null;
            return false;
        }

        private void ShowBooksTitle()
        {
            Console.WriteLine("Введите название книги: ");
            string userInput = Console.ReadLine().ToUpper();

            var filteredTitle = _book.Where(book => book.Title.ToUpper() == userInput);

            foreach (var book in filteredTitle)
            {
                Console.WriteLine($"{book.UniqueNumber}.Название: {book.Title} - автор: {book.Author} - год выпуска: {book.YearRelease}");
            }
        }

        private void ShowBooksAuthor()
        {
            Console.WriteLine("Введите название книги: ");
            string userInput = Console.ReadLine().ToUpper();

            var filteredTitle = _book.Where(book => book.Title.ToUpper() == userInput);

            foreach (var book in filteredTitle)
            {
                Console.WriteLine($"{book.UniqueNumber}.Название: {book.Title} - автор: {book.Author} - год выпуска: {book.YearRelease}");
            }
        }

        private void ShowBooksYearRelease()
        {
            Console.WriteLine("Введите год выпуска: ");
            string userInput = Console.ReadLine();

            var filteredTitle = _book.Where(book => book.Title == userInput);

            foreach (var book in filteredTitle)
            {
                Console.WriteLine($"{book.UniqueNumber}.Название: {book.Title} - автор: {book.Author} - год выпуска: {book.YearRelease}");
            }
        }

        private void RemoveBook()
        {
            if (TryGetBook(out Book book))
            {
                _book.Remove(book);
            }
            else
            {
                OutputText();
            }
        }

        private void ShowBook()
        {
            for (int i = 0; i < _book.Count; i++)
            {
                Console.WriteLine($"{_book[i].UniqueNumber}.Название: {_book[i].Title} - автор: {_book[i].Author} - год выпуска: {_book[i].YearRelease}");
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Введите название книги:");
            string title = Console.ReadLine();

            Console.WriteLine("Введите автора:");
            string author = Console.ReadLine();

            Console.WriteLine("Введите год выпуска:");

            if (int.TryParse(Console.ReadLine(), out int yearRelease) != false)
            {
                _bookId++;
                _book.Add(new Book(title, author, yearRelease, _bookId));
            }
            else
            {
                OutputText();
            }
        }

        private void OutputText()
        {
            Console.WriteLine("Ошибка ввода");
        }
    }

    class Book
    {
        public Book(string title, string author, int yearRelease, int uniqueNumber)
        {
            Title = title;
            Author = author;
            YearRelease = yearRelease;
            UniqueNumber = uniqueNumber;
        }

        public int UniqueNumber { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearRelease { get; private set; }
    }
}
