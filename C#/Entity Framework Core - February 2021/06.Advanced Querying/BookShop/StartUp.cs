namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
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
