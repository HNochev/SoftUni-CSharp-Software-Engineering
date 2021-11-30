using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                switch (input)
                {
                    case "Dog":
                        {
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        }
                    case "Cat":
                        {
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        }
                    case "Frog":
                        {
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        }
                    case "Kittens":
                        {
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            break;
                        }
                    case "Tomcat":
                        {
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            break;
                        }
                }

                input = Console.ReadLine();
            }
        }
    }
}
