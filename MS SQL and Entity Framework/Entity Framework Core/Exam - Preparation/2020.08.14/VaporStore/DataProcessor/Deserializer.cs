namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var games = new List<Game>();

            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var gameTags = new List<GameTag>();

            var gamesDtos = JsonConvert.DeserializeObject<GameJsonInputModel[]>(jsonString);

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count() <= 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer { Name = gameDto.Developer };
                    developers.Add(developer);
                }

                var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre { Name = gameDto.Genre };
                    genres.Add(genre);
                }

                var currentTags = new List<GameTag>();

                foreach (var tagName in gameDto.Tags)
                {
                    if (string.IsNullOrWhiteSpace(tagName))
                    {
                        continue;
                    }

                    GameTag gameTag;

                    if (gameTags.Select(x => x.Tag.Name).Contains(tagName))
                    {
                        gameTag = gameTags.FirstOrDefault(x => x.Tag.Name == tagName);
                    }
                    else
                    {
                        gameTag = new GameTag { Tag = new Tag { Name = tagName } };

                        gameTags.Add(gameTag);
                    }

                    currentTags.Add(gameTag);
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                    GameTags = currentTags,
                };

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var users = new List<User>();

            var usersDtos = JsonConvert.DeserializeObject<UserJsonInputModel[]>(jsonString);

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Cards = userDto.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type.Value,
                    })
                    .ToArray(),
                };

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var purchases = new List<Purchase>();

            var purchasesDtos = XmlConverter.Deserializer<PurchaseXmlInputModel>(xmlString, "Purchases");

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
                if(!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);
                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

                var purchase = new Purchase
                {
                    Type = purchaseDto.Type.Value,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = resultDate,
                    Game = game,
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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