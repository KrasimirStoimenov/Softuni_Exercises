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

            //03. Golden Books
            Console.WriteLine(GetGoldenBooks(db));


        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            //03. Golden Books

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
            //02.Age Restriction

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
