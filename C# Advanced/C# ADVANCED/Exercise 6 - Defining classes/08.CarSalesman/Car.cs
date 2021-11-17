using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string weightString = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            string colorString = string.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;

            string diplacementString = this.Engine.Displacement.HasValue ?
                this.Engine.Displacement.ToString() : "n/a";
            string efficiencyString = string.IsNullOrEmpty(this.Engine.Efficiency) ? "n/a" : this.Engine.Efficiency;

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            sb.AppendLine($"    Displacement: {diplacementString}");
            sb.AppendLine($"    Efficiency: {efficiencyString}");
            sb.AppendLine($"  Weight: {weightString}");
            sb.AppendLine($"  Color: {colorString}");
            return sb.ToString().TrimEnd();
        }
    }
}
