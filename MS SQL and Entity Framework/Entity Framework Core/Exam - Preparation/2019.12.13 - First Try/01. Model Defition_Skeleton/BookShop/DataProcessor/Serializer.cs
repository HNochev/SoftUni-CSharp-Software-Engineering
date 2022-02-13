namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCrazierAuthors = context.Authors
                .Include(x => x.AuthorsBooks)
                .ThenInclude(x => x.Book)
                .OrderByDescending(x => x.AuthorsBooks.Count)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Books = x.AuthorsBooks.Select(y => new
                    {
                        BookName = y.Book.Name,
                        BookPrice = y.Book.Price.Value.ToString("f2"),
                    })
                    .OrderByDescending(y => decimal.Parse(y.BookPrice))
                    .ToList()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(mostCrazierAuthors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(x => new OldBookOutputModel
                {
                    Pages = x.Pages.Value,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToList();

            var result = XmlConverter.Serialize(books, "Books");

            return result;
        }
    }
}