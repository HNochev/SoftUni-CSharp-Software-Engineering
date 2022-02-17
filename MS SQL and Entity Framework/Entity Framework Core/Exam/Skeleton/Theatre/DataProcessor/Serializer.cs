namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                    .Where(y => y.RowNumber >= 1 && y.RowNumber <= 5)
                    .Sum(y => y.Price),
                    Tickets = x.Tickets
                    .Where(y => y.RowNumber >= 1 && y.RowNumber <= 5)
                    .Select(y => new
                    {
                        Price = y.Price,
                        RowNumber = y.RowNumber,
                    })
                    .OrderByDescending(y => y.Price)
                    .ToList(),
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays.ToList()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXmlOutputModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(y => y.IsMainCharacter)
                    .Select(y => new ActorXmlOutputModel
                    {
                        FullName = y.FullName,
                        MainCharacter = y.IsMainCharacter ? $"Plays main character in '{y.Play.Title}'." : "",
                    })
                    .OrderByDescending(y => y.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToList();

            var result = XmlConverter.Serialize(plays, "Plays");

            return result;
        }
    }
}
