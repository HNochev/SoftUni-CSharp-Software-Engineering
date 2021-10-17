using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Article> artic = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);

                artic.Add(article);
            }
            string criteria = Console.ReadLine();
            switch (criteria)
            {
                case "title":
                    Console.WriteLine(string.Join(Environment.NewLine, artic.OrderBy(x => x.Title)));
                    break;
                case "content":
                    Console.WriteLine(string.Join(Environment.NewLine, artic.OrderBy(x => x.Content)));
                    break;
                case "author":
                    Console.WriteLine(string.Join(Environment.NewLine, artic.OrderBy(x => x.Author)));
                    break;
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            string text = ($"{Title} - {Content}: {Author}");

            return text;
        }
    }
}
