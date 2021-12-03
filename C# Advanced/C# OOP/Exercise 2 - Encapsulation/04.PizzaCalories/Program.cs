using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine()
                .Split();

            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string flourType = doughInput[1];
            string bakingTechnique = doughInput[2];
            int doughtWeight = int.Parse(doughInput[3]);

            try
            {

                Dough dough = new Dough(flourType, bakingTechnique, doughtWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string[] toppingInput = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (toppingInput[0] == "END")
                    {
                        break;
                    }

                    string toppingType = toppingInput[1];
                    int toppingWeight = int.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizzaName} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception ex)
             when (ex is ArgumentException ||
             ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
