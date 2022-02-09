namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();

            //Problem 15
            //Console.WriteLine(RemoveBooks(db));

            //Problem 14
            //IncreasePrices(db);

            //Problem 13
            //Console.WriteLine(GetMostRecentBooks(db));

            //Problem 12
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //Problem 11
            //Console.WriteLine(CountCopiesByAuthor(db));

            //Problem 10
            //Console.WriteLine(CountBooks(db, int.Parse(input)));

            //Problem 9
            //Console.WriteLine(GetBooksByAuthor(db, input));

            //Problem 8
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //Problem 7
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //Problem 6
            //Console.WriteLine(GetBooksReleasedBefore(db, input));

            //Problem 5
            //Console.WriteLine(GetBooksByCategory(db, input));

            //Problem 4
            //Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(input)));

            //Problem 3
            //Console.WriteLine(GetBooksByPrice(db));

            //Problem 2
            //Console.WriteLine(GetGoldenBooks(db));

            // Problem 1
            //Console.WriteLine(GetBooksByAgeRestriction(db, input));

        }

        //Problem 15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            int countDeletedBooks = books.Count;

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return countDeletedBooks;
        }

        //Problem 14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price = book.Price + 5;
            }

            context.SaveChanges();
        }

        //Problem 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesBooks = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Titles = x.CategoryBooks
                    .Select(y => new
                    {
                        Title = y.Book.Title,
                        ReleaseYear = y.Book.ReleaseDate,
                    })
                    .OrderByDescending(y => y.ReleaseYear)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            //string result = string.Join(Environment.NewLine, categoriesBooks.Select(x => $"--{x.CategoryName}{Environment.NewLine}{string.Join(Environment.NewLine, x.Titles.Select(y => $"{y.Title} ({y.ReleaseYear.Value.Year})"))}"));

            StringBuilder sb = new StringBuilder();

            foreach (var categories in categoriesBooks)
            {
                sb.AppendLine($"--{categories.CategoryName}");
                foreach (var title in categories.Titles)
                {
                    sb.AppendLine($"{title.Title} ({title.ReleaseYear.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(y => y.Book.Price * y.Book.Copies),
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, categories.Select(x => $"{x.CategoryName} ${x.TotalProfit:f2}"));

            return result;
        }

        //Problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    Count = x.Books.Sum(x => x.Copies),
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(x => $"{x.FullName} - {x.Count}"));

            return result;
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countOfBooksWithLongerTitle = context.Books
                .Where(x => x.Title.Length > lengthCheck).Count();

            return countOfBooksWithLongerTitle;
        }

        //Problem 9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authorsBooks = context.Authors
                .Where(x => EF.Functions.Like(x.LastName, $"{input}%"))
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    Titles = x.Books
                    .Select(y => new
                    {
                        y.Title,
                        y.BookId,
                    })
                    .OrderBy(x => x.BookId)
                    .ToList(),
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var authors in authorsBooks)
            {
                foreach (var titles in authors.Titles)
                {
                    sb.AppendLine($"{titles.Title} ({authors.FullName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //Problem 7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                })
                .OrderBy(x => x.FullName)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(x => x.FullName));

            return result;
        }

        //Problem 6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            int[] dayMonthYear = date.Split("-", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            DateTime inputDate = new DateTime(dayMonthYear[2], dayMonthYear[1], dayMonthYear[0]);

            var books = context.Books
                .Where(x => x.ReleaseDate < inputDate)
                .Select(x => new
                {
                    x.Title,
                    x.Price,
                    x.EditionType,
                    x.ReleaseDate,
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));

            return result;
        }

        //Problem 5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> inputCategories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var booksInCategories = context.BooksCategories
                .Where(x => inputCategories.Contains(x.Category.Name.ToLower()))
                .Select(x => x.Book.Title)
                .OrderBy(x => x)
                .ToList();

            string result = string.Join(Environment.NewLine, booksInCategories);

            return result;
        }

        //Problem 4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.Title,
                    x.BookId,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        //Problem 3
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price,
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:f2}"));

            return result;
        }

        //Problem 2
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x => new
                {
                    x.Title,
                    x.BookId,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        //Problem 1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                 .Where(x => x.AgeRestriction == ageRestriction)
                 .Select(x => x.Title)
                 .OrderBy(x => x)
                 .ToList();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
