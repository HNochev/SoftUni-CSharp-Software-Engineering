using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate = false;

        private List<ICar> cars;

        public Driver(string name)
        {
            this.Name = name;
            this.cars = new List<ICar>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set
            {
                this.canParticipate = value;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }
            cars.Add(car);
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
