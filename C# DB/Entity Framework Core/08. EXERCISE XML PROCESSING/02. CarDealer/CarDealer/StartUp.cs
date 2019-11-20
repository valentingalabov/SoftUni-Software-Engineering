using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using AutoMapper.QueryableExtensions;
using CarDealer.Dtos.Export;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //string InputXML = File.ReadAllText("./../../../Datasets/sales.xml");

                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }

        //09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var XmlSerializer =
                new XmlSerializer(typeof(ImportSupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDtos;

            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (ImportSupplierDto[])XmlSerializer.Deserialize(reader);

            }

            var suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";

        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                                new XmlRootAttribute("Parts"));

            ImportPartDto[] partDtos;

            using (var reader = new StringReader(inputXml))
            {
                partDtos = ((ImportPartDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                    .ToArray();
            }

            var parts = Mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";

        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),
                new XmlRootAttribute("Cars"));

            ImportCarDto[] carDtos;

            using (var reader = new StringReader(inputXml))
            {
                carDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance

                };


                var parts = carDto
                    .PartCars
                    .Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var partId in parts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        Car = car

                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);

            context.PartCars.AddRange(partCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }


        //12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;

            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (ImportCustomerDto[])XmlSerializer.Deserialize(reader);
            }

            var customers = Mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
                                new XmlRootAttribute("Sales"));

            ImportSalesDto[] salesDtos;

            using (var reader = new StringReader(inputXml))
            {
                salesDtos = ((ImportSalesDto[])XmlSerializer
                                                    .Deserialize(reader))
                                                    .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                                                    .ToArray();
            }

            var sales = Mapper.Map<Sale[]>(salesDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";



        }

        //14. Export Cars With Distance

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var cars =
                context
                .Cars
                .ProjectTo<ExportCarWithDistanceDto>()
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var XmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]),
                                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");


            using (var writer = new StringWriter(sb))
            {
                XmlSerializer.Serialize(writer, cars, namespaces);
            }


            return sb.ToString().TrimEnd();
        }

        //15. Export Cars From Make BMW

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars =
                context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportBMWCars>()
                .ToArray();

            var XmlSerializer = new XmlSerializer(typeof(ExportBMWCars[]),
                               new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                XmlSerializer.Serialize(writer, cars, namespaces);
            }


            return sb.ToString().TrimEnd();
        }

        //16. Export Local Suppliers

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var suppliers =
                context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSuppliersDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]),
                                new XmlRootAttribute("suppliers"));


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, suppliers, namespaces);

            }

            return sb.ToString().TrimEnd();


        }

        //17. Export Cars With Their List Of Parts

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            StringBuilder sb = new StringBuilder();


            var cars =
                context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarDto>()
                .ToArray();

            foreach (var car in cars)
            {
                car.Parts = car.Parts.OrderByDescending(p => p.Price).ToArray();
            }


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]),
                                          new XmlRootAttribute("cars"));


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);

            }

            return sb.ToString().TrimEnd();


        }


        //18. Export Total Sales By Customer

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var customers =
                context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerWithTotalSalesDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Select(x=>x.CarId).Count(),
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))

                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var XmlSerializer = new XmlSerializer(typeof(ExportCustomerWithTotalSalesDto[]),
                                new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                XmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();


        }

        //19. Export Sales With Applied Discount

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

            StringBuilder sb = new StringBuilder();

            var cars = context
          .Sales
          .Select(s => new ExportSalesWithDiscountDto
          {
              Car = new CarSalesDto
              {
                  Make = s.Car.Make,
                  Model = s.Car.Model,
                  TravelledDistance = s.Car.TravelledDistance
              },
              CustomerName = s.Customer.Name,
              Discount = s.Discount,
              Price = s.Car.PartCars.Sum(x => x.Part.Price),
              PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) - s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100
                //PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) * ((100 - s.Discount) / 100)
            })
          .ToArray();

            var XmlSerializer = new XmlSerializer(typeof(ExportSalesWithDiscountDto[]),
                                new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                XmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}