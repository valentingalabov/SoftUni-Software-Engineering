namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Newtonsoft.Json;
    using Cinema.DataProcessor.ImportDto;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2:F2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<Movie[]>(jsonString);

            var validMovies = new List<Movie>();

            var sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                var isValidEnum = Enum.TryParse(movieDto.Genre.ToString(), out Genre genre);

                var isTitleExist = validMovies.FirstOrDefault(m => m.Title == movieDto.Title);


                if (!IsValid(movieDto) || !isValidEnum || isTitleExist != null)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    Duration = movieDto.Duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director

                };

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, movieDto.Rating));



            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();


        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<HallDto[]>(jsonString);

            var validHalls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {


                if (!IsValid(hallDto) || hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D,

                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat { });
                }

                validHalls.Add(hall);

                string projectionType;

                if (hall.Is3D && hall.Is4Dx)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else if (hall.Is4Dx)
                {
                    projectionType = "4Dx";
                }
                else
                {
                    projectionType = "Normal";
                }
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));


            }

            context.Halls.AddRange(validHalls);

            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProjectionDto[]),
                                new XmlRootAttribute("Projections"));

            var projections = (ProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validProjections = new List<Projection>();

            foreach (var projection in projections)
            {
                var hallIsValid = context.Halls.Find(projection.HallId);
                var movieIsValid = context.Movies.Find(projection.MovieId);

                if (hallIsValid == null || movieIsValid == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectionToAdd = new Projection
                {
                    MovieId = projection.MovieId,
                    HallId = projection.HallId,
                    DateTime = DateTime.ParseExact(projection.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

                };


                var projectionDateTime = DateTime.Parse(projection.DateTime, CultureInfo.InvariantCulture);

                validProjections.Add(projectionToAdd);

                sb.AppendLine(string.Format(SuccessfulImportProjection, movieIsValid.Title, projectionDateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();


            return sb.ToString().TrimEnd();

        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomerTicketsDto[]),
                               new XmlRootAttribute("Customers"));

            var customers = (CustomerTicketsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validCustomer = new List<Customer>();

            foreach (var customer in customers)
            {
                var projections = context.Projections.Select(x => x.Id).ToArray();
                var existingProjections = projections.Any(x => customer.Tickets.Any(t => t.ProjectionId != x));


                if (!IsValid(customer) && customer.Tickets.All(IsValid) && existingProjections)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }

                var customerToAdd = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Age = customer.Age,
                    Balance = customer.Balance,


                };

                foreach (var ticket in customer.Tickets)
                {
                    customerToAdd.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price

                    });
                }

                validCustomer.Add(customerToAdd);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customerToAdd.Tickets.Count));

            }

            context.Customers.AddRange(validCustomer);
            context.SaveChanges();



            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validationContex = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContex, validationResult, true);

        }
    }
}