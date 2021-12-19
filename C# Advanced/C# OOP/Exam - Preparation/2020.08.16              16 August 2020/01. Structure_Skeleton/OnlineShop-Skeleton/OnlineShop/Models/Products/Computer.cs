using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + components.Average(x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price => base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            double averageOverallPerformanceOfPeripherals = 0;

            if(this.Peripherals.Any())
            {
                averageOverallPerformanceOfPeripherals = this.Peripherals.Average(x => x.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({averageOverallPerformanceOfPeripherals:f2}):");
            foreach (var periperial in peripherals)
            {
                sb.AppendLine($"  {periperial}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent component = components.First(x => x.GetType().Name == componentType);
            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral peripherial = peripherals.First(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripherial);

            return peripherial;
        }
    }
}
