using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in personInput)
            {
                string[] nameMoney = item
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = nameMoney[0];
                decimal money = decimal.Parse(nameMoney[1]);

                try
                {
                    Person person = new Person(name, money);

                    people.Add(person);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in productInput)
            {
                string[] namePrice = item
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = namePrice[0];
                decimal price = decimal.Parse(namePrice[1]);

                try
                {
                    Product product = new Product(name, price);

                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string[] personProduct = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personProduct[0] == "END")
                {
                    break;
                }

                string personName = personProduct[0];
                string productName = personProduct[1];

                Person person = people
                    .Where(p => p.Name == personName)
                    .FirstOrDefault();

                Product product = products
                    .Where(p => p.Name == productName)
                    .FirstOrDefault();

                person.AddProduct(product);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
