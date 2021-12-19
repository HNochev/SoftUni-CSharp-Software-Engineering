using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> drivers;
        private IRepository<ICar> cars;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            string typeCar = string.Empty;
            if (type == "Muscle")
            {
                cars.Add(new MuscleCar(model, horsePower));
                typeCar = "MuscleCar";
            }
            else if (type == "Sports")
            {
                cars.Add(new SportsCar(model, horsePower));
                typeCar = "SportsCar";
            }

            return $"{typeCar} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            else
            {
                drivers.Add(new Driver(driverName));
                return $"Driver {driverName} is created.";
            }
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            races.Add(new Race(name, laps));
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else
            {
                if (races.GetByName(raceName).Drivers.Count < 3)
                {
                    throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
                }
                else
                {
                    var race = races.GetByName(raceName);

                    var sortedDrivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps));

                    string firstName = "";
                    string secondName = "";
                    string thirdName = "";

                    int counter = 1;
                    foreach (var item in sortedDrivers)
                    {
                        if (counter == 1)
                        {
                            firstName = item.Name;
                        }
                        else if (counter == 2)
                        {
                            secondName = item.Name;
                        }
                        else if (counter == 3)
                        {
                            thirdName = item.Name;
                        }
                        else
                        {
                            break;
                        }
                        counter++;
                    }
                    races.Remove(race);

                    return $"Driver {firstName} wins {raceName} race." + Environment.NewLine +
    $"Driver {secondName} is second in {raceName} race." + Environment.NewLine +
    $"Driver {thirdName} is third in {raceName} race.";
                }
            }
        }
    }
}
