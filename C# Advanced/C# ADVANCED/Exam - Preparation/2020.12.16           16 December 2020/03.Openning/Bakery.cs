using BakeryOpenning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (this.Employees.Count < Capacity)
            {
                this.Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (this.Employees.Any(x => x.Name == name))
            {
                Employees.Remove(Employees.Where(x => x.Name == name).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestOne = new Employee(string.Empty, 0, string.Empty);
            foreach (var employee in this.Employees)
            {
                if (oldestOne.Age < employee.Age)
                {
                    oldestOne = employee;
                }
            }
            return oldestOne;
        }

        public Employee GetEmployee(string name)
        {
            return Employees.Where(x => x.Name == name).FirstOrDefault();
        }

        public int Count { get => Employees.Count; }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            sb.AppendLine($"{string.Join(Environment.NewLine, this.Employees)}");

            return sb.ToString().TrimEnd();
        }
    }
}
