namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .ToArray()
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
                        Players = y.Purchases.Count,
                    })
                    .OrderByDescending(y => y.Players)
                    .ThenBy(y => y.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(p => p.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var result = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new UserOutputModel()
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                            .ToArray()
                            .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
                            .OrderBy(p => p.Date)
                            .Select(p => new PurchaseOutputModel()
                            {
                                Card = p.Card.Number,
                                Cvc = p.Card.Cvc,
                                Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                Game = new GameOutputModel()
                                {
                                    Title = p.Game.Name,
                                    Genre = p.Game.Genre.Name,
                                    Price = p.Game.Price
                                }
                            })
                            .ToArray(),
                    TotalSpent = context.Purchases
                                    .ToArray()
                                    .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
                                    .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var result = XmlConverter.Serialize(users, "Users");

            return result;
        }
    }
}