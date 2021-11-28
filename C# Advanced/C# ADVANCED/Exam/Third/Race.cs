using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => this.data.Count; }

        public void Add(Racer racer)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.Any(c => c.Name == name))
            {
                this.data.Remove(this.data.Where(c => c.Name == name).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Racer GetOldestRacer()
        {
            return this.data.OrderByDescending(c => c.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return this.data.Where(c => c.Name == name).FirstOrDefault();
        }

        public Racer GetFastestRacer()
        {
            return this.data.OrderByDescending(c => c.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in this.data)
            {
                sb.AppendLine($"{item}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
