using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using XmlFacade;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partXml = File.ReadAllText("../../../Datasets/parts.xml");
            ////var carPartsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //ImportSuppliers(context, supplierXml);
            //ImportParts(context, partXml);
            //ImportCars(context, carPartsXml);
            //ImportCustomers(context, customersXml);
            //var result = ImportSales(context, salesXml);

            //Ptoblem 14
            //var result = GetCarsWithDistance(context);

            //Ptoblem 15
            //var result = GetCarsFromMakeBmw(context);

            //Ptoblem 16
            //var result = GetLocalSuppliers(context);

            //Ptoblem 17
            //var result = GetCarsWithTheirListOfParts(context);

            //Problem 18
            //var result = GetTotalSalesByCustomer(context);

            //Problem 19
            var result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        //Not Using XMLHelper
        /*public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            var textRead = new StringReader(inputXml);

            var supplierDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];

            var suppliers = supplierDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }*/

        //Using XML Helper
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var supplierDto = XmlConverter.Deserializer<SupplierInputModel>(inputXml, root);

            var suppliers = supplierDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            var textRead = new StringReader(inputXml);

            var partDto = xmlSerializer.Deserialize(textRead) as PartInputModel[];

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partDto
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId,
                })
            .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var cars = new List<Car>();
            var carsDtos = XmlConverter.Deserializer<CarInputModel>(inputXml, root);

            var allParts = context.Parts.Select(x => x.Id).ToList();

            foreach (var currentCar in carsDtos)
            {
                var distinctedParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();

                var parts = distinctedParts.Intersect(allParts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part,
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";

            var customerDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);

            var customers = customerDto.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver,
            })
            .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var saleDto = XmlConverter.Deserializer<SaleInputModel>(inputXml, root);

            var cars = context.Cars.Select(x => x.Id).ToList();

            var sales = saleDto
                .Where(x => cars.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount,
                })
                .ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14 WITHOUT XMLHelper
        /*public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            var result = textWriter.ToString();

            return result;
        }*/

        //Problem 14 WITH XMLHelper
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var result = XmlConverter.Serialize<CarOutputModel>(cars, "cars");

            return result;
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmws = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BMWCarsOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var result = XmlConverter.Serialize<BMWCarsOutputModel>(bmws, "cars");

            return result;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count,
                })
                .ToArray();

            var result = XmlConverter.Serialize<LocalSuppliersOutputModel>(suppliers, "suppliers");

            return result;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarWithPartsOutputModel
                {
                    Model = x.Model,
                    Make = x.Make,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new PartsOutputModel
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price,
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize<CarWithPartsOutputModel>(cars, "cars");

            return result;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                    .Select(y => y.Car)
                    .SelectMany(y => y.PartCars)
                    .Sum(y => y.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var result = XmlConverter.Serialize<CustomerOutputModel>(customers, "customers");

            return result;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SaleOutputModel
                {
                    Car = new CarForSalesOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    Dicount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars
                    .Select(y => y.Part.Price)
                    .Sum(),
                    PriceWithDiscount = x.Car.PartCars
                    .Select(y => y.Part.Price)
                    .Sum() - x.Car.PartCars
                    .Select(y => y.Part.Price)
                    .Sum() * x.Discount / 100m,
                })
                .ToArray();

            var result = XmlConverter.Serialize<SaleOutputModel>(sales, "sales");

            return result;
        }
    }
}