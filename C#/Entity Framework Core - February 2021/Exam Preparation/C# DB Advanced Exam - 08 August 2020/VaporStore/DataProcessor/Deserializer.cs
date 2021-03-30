namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesJson = JsonConvert.DeserializeObject<IEnumerable<GameInputModel>>(jsonString);

            foreach (var gameJson in gamesJson)
            {
                if (!IsValid(gameJson) || gameJson.Tags.Count() == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(g => g.Name == gameJson.Genre)
                    ?? new Genre() { Name = gameJson.Genre };

                var developer = context.Developers.FirstOrDefault(d => d.Name == gameJson.Developer)
                    ?? new Developer() { Name = gameJson.Developer };


                var game = new Game()
                {
                    Name = gameJson.Name,
                    Price = gameJson.Price,
                    ReleaseDate = gameJson.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tag in gameJson.Tags)
                {
                    var currentTag = context.Tags.FirstOrDefault(t => t.Name == tag)
                        ?? new Tag() { Name = tag };

                    context.GameTags.Add(new GameTag { Game = game, Tag = currentTag });
                }

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersJson = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(jsonString);

            foreach (var userJson in usersJson)
            {
                if (!IsValid(userJson) || !userJson.Cards.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = userJson.FullName,
                    Username = userJson.Username,
                    Age = userJson.Age,
                    Email = userJson.Email,
                    Cards = userJson.Cards.Select(x => new Card
                    {
                        Cvc = x.CVC,
                        Number = x.Number,
                        Type = x.Type.Value
                    })
                    .ToList()
                };

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(PurchaseInputModel[]), new XmlRootAttribute("Purchases"));

            var purchasesXml = xmlSerializer.Deserialize(new StringReader(xmlString)) as PurchaseInputModel[];

            foreach (var purchaseXml in purchasesXml)
            {
                if (!IsValid(purchaseXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validDate = DateTime.TryParseExact(purchaseXml.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                if (!validDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase()
                {
                    Game = context.Games.FirstOrDefault(g => g.Name == purchaseXml.GameName),
                    Type = purchaseXml.Type.Value,
                    Date = parsedDate,
                    ProductKey = purchaseXml.Key,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchaseXml.CardNumber)
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();

                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

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