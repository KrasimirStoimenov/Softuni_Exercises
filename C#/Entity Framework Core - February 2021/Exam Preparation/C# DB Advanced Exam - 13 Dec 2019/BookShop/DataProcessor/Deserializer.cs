namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(BookInputModel[]), new XmlRootAttribute("Books"));
            var xmlBooks = xmlSerializer.Deserialize(new StringReader(xmlString)) as BookInputModel[];

            var validBooks = new List<Book>();

            foreach (var book in xmlBooks)
            {
                var isGenreValid = Enum.TryParse<Genre>(book.Genre, out var genre);
                var isDateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var publishedDate);

                if (!IsValid(book) || !isGenreValid || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validBook = new Book
                {
                    Name = book.Name,
                    Genre = genre,
                    Pages = book.Pages,
                    Price = book.Price,
                    PublishedOn = publishedDate
                };

                validBooks.Add(validBook);

                var bookSuccessfullMessage = string.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price);
                sb.AppendLine(bookSuccessfullMessage);
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authors = JsonConvert.DeserializeObject<IEnumerable<AuthorInputModel>>(jsonString);

            var validAuthors = new List<Author>();
            foreach (var author in authors)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validAuthors.Any(x => x.Email == author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validAuthor = new Author
                {
                    FirstName = author.FirstName,
                    Email = author.Email,
                    LastName = author.LastName,
                    Phone = author.Phone,
                };

                foreach (var book in author.Books)
                {
                    if (!IsValid(book))
                    {
                        continue;
                    }
                    var validBook = context.Books.FirstOrDefault(x => x.Id == book.Id.Value);
                    if (validBook == null)
                    {
                        continue;
                    }

                    validAuthor.AuthorsBooks.Add(new AuthorBook() { Book = validBook });
                }

                if (validAuthor.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAuthors.Add(validAuthor);
                var authorSuccessfullMessage = string.Format(SuccessfullyImportedAuthor, validAuthor.FirstName + " " + validAuthor.LastName, validAuthor.AuthorsBooks.Count);

                sb.AppendLine(authorSuccessfullMessage);
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}