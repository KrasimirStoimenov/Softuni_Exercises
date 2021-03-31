namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Select(x => new
                    {
                        Id = x.Id,
                        Title = x.Name,
                        Developer = x.Developer.Name,
                        Tags = string.Join(", ", x.GameTags.Select(gt => gt.Tag.Name)),
                        Players = x.Purchases.Count
                    })
                    .Where(x => x.Players > 0)
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id),

                    TotalPlayers = g.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);

            var serialized = JsonConvert.SerializeObject(games, Formatting.Indented);

            return serialized.ToString();
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {

            var users = context.Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(t => t.Type.ToString() == storeType)))
                .Select(u => new UserExportModel
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(p => p.Purchases)
                                       .Where(p => p.Type.ToString() == storeType)
                                       .Select(p => new PurchaseExportModel
                                       {
                                           CardNumber = p.Card.Number,
                                           Cvc = p.Card.Cvc,
                                           Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                           Game = new GameExportModel
                                           {
                                               GameName = p.Game.Name,
                                               Genre = p.Game.Genre.Name,
                                               Price = p.Game.Price
                                           }
                                       })
                                       .OrderBy(x => x.Date)
                                       .ToArray(),
                    TotalSpent = u.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(g => g.Game.Price))

                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserExportModel[]), new XmlRootAttribute("Users"));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), users, ns);

            return sb.ToString().TrimEnd();
        }
    }
}