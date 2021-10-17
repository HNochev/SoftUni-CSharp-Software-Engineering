using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }
            Console.WriteLine(article.ToString());

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
        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            string text = ($"{Title} - {Content}: {Author}");

            return text;
        }
    }
}
