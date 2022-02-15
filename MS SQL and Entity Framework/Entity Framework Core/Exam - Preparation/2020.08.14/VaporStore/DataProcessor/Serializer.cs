namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres.ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(y => y.Purchases.Count > 0)
                    .Select(y => new
                    {
                        Id = y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = string.Join(", ", y.GameTags.Select(z => z.Tag.Name)),
                        Players = y.Purchases.Count
                    })
                    .OrderByDescending(y => y.Players)
                    .ThenBy(y => y.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(y => y.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var result = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users.ToList()
                .Where(x => x.Cards.Any(y => y.Purchases.Any(z => z.Type.ToString() == storeType)))
                .Select(x => new UserXmlOutputModel
                {
                    Username = x.Username,
                    Purchases = x.Cards.SelectMany(y => y.Purchases)
                        .Where(y => y.Type.ToString() == storeType)
                        .Select(y => new PurchaseXmlOutputModel
                        {
                            Card = y.Card.Number,
                            Cvc = y.Card.Cvc,
                            Date = y.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameXmlOutputModel
                            {
                                Title = y.Game.Name,
                                Genre = y.Game.Genre.Name,
                                Price = y.Game.Price,
                            }
                        })
                    .OrderBy(y => y.Date)
                    .ToArray(),
                    TotalSpent = x.Cards
                    .Sum(c => c.Purchases
                        .Where(p => p.Type.ToString() == storeType)
                        .Sum(p => p.Game.Price)),
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToList();

            var result = XmlConverter.Serialize(users, "Users");

            return result;
        }
    }
}