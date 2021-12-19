using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targetComputer = computers.First(c => c.Id == computerId);

                if (components.Any(x => x.Id == id))
                {
                    throw new ArgumentException($"Component with this id already exists.");
                }


                if (componentType == "CentralProcessingUnit")
                {
                    targetComputer.AddComponent(new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else if (componentType == "Motherboard")
                {
                    targetComputer.AddComponent(new Motherboard(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new Motherboard(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else if (componentType == "PowerSupply")
                {
                    targetComputer.AddComponent(new PowerSupply(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new PowerSupply(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else if (componentType == "RandomAccessMemory")
                {
                    targetComputer.AddComponent(new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else if (componentType == "SolidStateDrive")
                {
                    targetComputer.AddComponent(new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else if (componentType == "VideoCard")
                {
                    targetComputer.AddComponent(new VideoCard(id, manufacturer, model, price, overallPerformance, generation));
                    components.Add(new VideoCard(id, manufacturer, model, price, overallPerformance, generation));
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
                else
                {
                    throw new ArgumentException("Component type is invalid.");
                }
            }
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Computer with this id already exists.");
            }

            if (computerType == "DesktopComputer")
            {
                computers.Add(new DesktopComputer(id, manufacturer, model, price));
                return $"Computer with id {id} added successfully.";
            }
            else if (computerType == "Laptop")
            {
                computers.Add(new Laptop(id, manufacturer, model, price));
                return $"Computer with id {id} added successfully.";
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targetComputer = computers.First(c => c.Id == computerId);

                if (peripherals.Any(x => x.Id == id))
                {
                    throw new ArgumentException($"Peripheral with this id already exists.");
                }

                IPeripheral peripheral = null;

                if (peripheralType == "Headset")
                {
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (peripheralType == "Keyboard")
                {
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (peripheralType == "Monitor")
                {
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (peripheralType == "Mouse")
                {
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else
                {
                    throw new ArgumentException("Peripheral type is invalid.");
                }

                targetComputer.AddPeripheral(peripheral);
                peripherals.Add(peripheral);
                return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
            }
        }

        public string BuyBest(decimal budget)
        {
            var filteredComputers = computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).ThenByDescending(x => x.Price).ToList();

            if (filteredComputers.Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            else
            {
                IComputer bestComputer = filteredComputers[0];
                computers.Remove(bestComputer);

                return bestComputer.ToString();

            }
        }

        public string BuyComputer(int id)
        {
            if (!computers.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targeterdComputer = computers.First(c => c.Id == id);

                computers.Remove(targeterdComputer);

                return targeterdComputer.ToString();
            }
        }

        public string GetComputerData(int id)
        {
            if (!computers.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targeterdComputer = computers.First(c => c.Id == id);

                return targeterdComputer.ToString();
            }
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targetComputer = computers.First(c => c.Id == computerId);


                IComponent component = targetComputer.RemoveComponent(componentType);
                components.Remove(component);

                return $"Successfully removed {componentType} with id {component.Id}.";
            }
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
            else
            {
                IComputer targetComputer = computers.First(c => c.Id == computerId);


                IPeripheral peripheral = targetComputer.RemovePeripheral(peripheralType);
                peripherals.Remove(peripheral);

                return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
            }
        }
    }
}
