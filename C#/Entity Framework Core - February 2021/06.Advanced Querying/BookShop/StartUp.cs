namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //01.Book Shop Database
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //02. Age Restriction
            Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            Console.WriteLine(new string('-', 40));

            //03. Golden Books
            Console.WriteLine(GetGoldenBooks(db));
            Console.WriteLine(new string('-', 40));

            //04. Books by Price
            Console.WriteLine(GetBooksByPrice(db));
            Console.WriteLine(new string('-', 40));

            //05. Not Released In
            Console.WriteLine(GetBooksNotReleasedIn(db, 2000));
            Console.WriteLine(new string('-', 40));

            //06. Book Titles by Category
            Console.WriteLine(GetBooksByCategory(db, "horror mystery drama    "));
            Console.WriteLine(new string('-', 40));

            //07. Released Before Date
            Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
            Console.WriteLine(new string('-', 40));

            //08. Author Search
            Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
            Console.WriteLine(new string('-', 40));

            //09. Book Search
            Console.WriteLine(GetBookTitlesContaining(db, "sK"));
            Console.WriteLine(new string('-', 40));

            //10. Book Search by Author
            Console.WriteLine(GetBooksByAuthor(db, "R"));
            Console.WriteLine(new string('-', 40));

            //11. Count Books
            Console.WriteLine(CountBooks(db, 12));
            Console.WriteLine(new string('-', 40));

            //12. Total Book Copies
            Console.WriteLine(CountCopiesByAuthor(db));
            Console.WriteLine(new string('-', 40));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksInCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in booksInCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfit = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            var result = string.Join(Environment.NewLine, categoriesProfit.Select(x => $"{x.CategoryName} ${x.Profit:F2}"));

            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Sum(book => book.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            var result = string.Join(Environment.NewLine, copies.Select(x => $"{x.AuthorName} - {x.Copies}"));

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(book => book.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(book => book.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title,
                    Author = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .OrderBy(x => x.Id)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.Author})"));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var result = string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName}"));

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateFormat = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(book => book.ReleaseDate < dateFormat)
                .Select(x => new
                {
                    ReleaseDate = x.ReleaseDate,
                    Title = x.Title,
                    Type = x.EditionType,
                    Price = x.Price
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.Type} - ${x.Price:F2}"));

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var books = context.BooksCategories
                .Where(category => categories.Contains(category.Category.Name.ToLower()))
                .Select(book => new
                {
                    Title = book.Book.Title
                })
                .OrderBy(bt => bt.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(t => t.Title));

            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.Id)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(t => t.Title));

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:F2}"));

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.EditionType == EditionType.Gold && book.Copies < 5000)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.Id)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(t => t.Title));

            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(book => book.AgeRestriction == ageRestriction)
                .Select(x => new
                {
                    Title = x.Title
                })
                .OrderBy(x => x.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(t => t.Title));

            return result;
        }
    }
}
