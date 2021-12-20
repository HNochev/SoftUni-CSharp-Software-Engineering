using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private decimal income;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                IDrink drink = new Tea(name, portion, brand);
                drinks.Add(drink);
            }
            else if (type == "Water")
            {
                IDrink drink = new Water(name, portion, brand);
                drinks.Add(drink);
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                IBakedFood food = new Bread(name, price);
                bakedFoods.Add(food);
            }
            else if (type == "Cake")
            {
                IBakedFood food = new Cake(name, price);
                bakedFoods.Add(food);
            }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                ITable table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
            }
            else if (type == "OutsideTable")
            {
                ITable table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(t=>t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();

            decimal bill = table.GetBill();
            income = income + bill;
            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine +
                    $"Bill: {bill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = drinks.Where(f => f.Name == drinkName && f.Brand == drinkBrand).FirstOrDefault();
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IBakedFood food = bakedFoods.Where(f => f.Name == foodName).FirstOrDefault();
                if (food == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.Where(x => x.IsReserved == false && x.Capacity >= numberOfPeople).FirstOrDefault();

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
