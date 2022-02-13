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
    using SoftJail.DataProcessor;
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
            StringBuilder sb = new StringBuilder();

            var books = new List<Book>();

            var booksDtos = XmlConverter.Deserializer<BookXmlImputModel>(xmlString, "Books");

            foreach (var bookDto in booksDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var date = DateTime.ParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var book = new Book
                {
                    Name = bookDto.Name,
                    Genre = Enum.Parse<Genre>(bookDto.Genre),
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = date,
                };

                books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authors = new List<Author>();

            var authorsDtos = JsonConvert.DeserializeObject<AuthorJsonInputModel[]>(jsonString);

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                //var emails = context.Authors.Select(x => x.Email);

                //if (emails.Contains(authorDto.Email))
                //{
                //    sb.AppendLine("Invalid data!");
                //    continue;
                //}

                bool doesEmailExists = authors
                   .FirstOrDefault(x => x.Email == authorDto.Email) != null;

                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var booksIds = context.Books.Select(x => x.Id);

                var booksToAdd = new List<AuthorBook>();

                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.Id.HasValue || !booksIds.Contains(bookDto.Id.Value))
                    {
                        continue;
                    }

                    var book = context.Books.FirstOrDefault(x => x.Id == bookDto.Id);

                    var authorBook = new AuthorBook
                    {
                        Book = book,
                    };

                    booksToAdd.Add(authorBook);
                }

                if (booksToAdd.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email,
                    AuthorsBooks = booksToAdd,
                };

                authors.Add(author);
                sb.AppendLine($"Successfully imported author - {author.FirstName} {author.LastName} with {author.AuthorsBooks.Count} books.");
            }

            context.Authors.AddRange(authors);
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