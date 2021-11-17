using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = inputEngine[0];
                int power = int.Parse(inputEngine[1]);

                Engine engine = null;

                if (inputEngine.Length == 4)
                {
                    int displacement = int.Parse(inputEngine[2]);
                    string efficiency = inputEngine[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (inputEngine.Length == 3)
                {
                    int displacement;

                    bool isDisplacement = int.TryParse(inputEngine[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, inputEngine[2]);
                    }
                }
                else if (inputEngine.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] inputCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = null;

                string model = inputCar[0];
                Engine engine = engines.Where(x => x.Model == inputCar[1]).FirstOrDefault();

                if (inputCar.Length == 4)
                {
                    int weight = int.Parse(inputCar[2]);
                    string color = inputCar[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (inputCar.Length == 3)
                {
                    int weight;

                    bool isWeight = int.TryParse(inputCar[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, inputCar[2]);
                    }
                }
                else if (inputCar.Length == 2)
                {
                    car = new Car(model, engine);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
