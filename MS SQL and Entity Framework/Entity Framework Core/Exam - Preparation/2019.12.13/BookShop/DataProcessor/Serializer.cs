namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
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
            var authors = context.Authors
                .OrderByDescending(x => x.AuthorsBooks.Count)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Books = x.AuthorsBooks
                    .OrderByDescending(y => y.Book.Price)
                    .Select(y => new
                    {
                        BookName = y.Book.Name,
                        BookPrice = y.Book.Price.Value.ToString("f2"),
                    })
                    .ToList()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books.ToList()
                .Where(x => x.PublishedOn < date && x.Genre.ToString() == "Science")
                .Select(x => new BookXmlOutputModel
                {
                    Pages = x.Pages.Value,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToList();

            var result = XmlConverter.Serialize(books, "Books");

            return result;
        }
    }
}