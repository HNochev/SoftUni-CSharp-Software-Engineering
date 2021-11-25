using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                this.data.Remove(this.data.Where(c => c.Manufacturer == manufacturer && c.Model == model).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car GetLatestCar()
        {
            return this.data.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.data.Where(c => c.Manufacturer == manufacturer && c.Model == model).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in this.data)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
