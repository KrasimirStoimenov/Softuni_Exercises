using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BookShop.Data.Models;
using BookShop.DataProcessor.ExportDto;
using BookShop.Data;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace BookShop.DataProcessor
{
    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks.Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString()
                    })
                    .OrderByDescending(x => x.BookPrice)
                    .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName);

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre.ToString() == "Science")
                .Select(x => new OldestBooksExportModel
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture)
                })
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(OldestBooksExportModel[]), new XmlRootAttribute("Books"));
            var sb = new StringBuilder();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            serializer.Serialize(new StringWriter(sb), books, ns);

            return sb.ToString().TrimEnd();
        }
    }
}