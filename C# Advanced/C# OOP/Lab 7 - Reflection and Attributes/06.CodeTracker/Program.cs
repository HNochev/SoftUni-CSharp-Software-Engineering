using System;

namespace AuthorProblem
{
    [Author("UserOne")]
    public class StartUp
    {
        [Author("UserTwo")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
