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

            var result = string.Join(Environment.NewLine,books.Select(t=>t.Title));

            return result;
        }
    }
}
