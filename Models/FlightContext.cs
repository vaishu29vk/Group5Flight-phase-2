using Microsoft.EntityFrameworkCore;

namespace Group5Flight.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; } = null!;
        public DbSet<Airline> Airlines { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Airlines
            builder.Entity<Airline>().HasData(
                new Airline { AirlineId = 1, Name = "Delta Air Lines", ImageName = "delta.jpg" },
                new Airline { AirlineId = 2, Name = "United Airlines", ImageName = "united.png" },
                new Airline { AirlineId = 3, Name = "American Airlines", ImageName = "american.png" },
                new Airline { AirlineId = 4, Name = "Southwest Airlines", ImageName = "southwest.png" }
            );

            // Flights (MODIFIED DATA)
            builder.Entity<Flight>().HasData(
                new Flight
                {
                    FlightId = 1,
                    FlightCode = "DL900",
                    From = "Chicago",
                    To = "Dallas",
                    Date = new DateTime(2026, 6, 5),
                    DepartureTime = new TimeSpan(7, 30, 0),
                    ArrivalTime = new TimeSpan(10, 15, 0),
                    CabinType = "Economy",
                    AircraftType = "Boeing 737-900",
                    Emission = 170,
                    Price = 210m,
                    AirlineId = 1
                },
                new Flight
                {
                    FlightId = 2,
                    FlightCode = "UA455",
                    From = "Dallas",
                    To = "Seattle",
                    Date = new DateTime(2026, 6, 5),
                    DepartureTime = new TimeSpan(11, 0, 0),
                    ArrivalTime = new TimeSpan(14, 20, 0),
                    CabinType = "Economy Plus",
                    AircraftType = "Airbus A321",
                    Emission = 230,
                    Price = 295m,
                    AirlineId = 2
                },
                new Flight
                {
                    FlightId = 3,
                    FlightCode = "AA880",
                    From = "Seattle",
                    To = "San Francisco",
                    Date = new DateTime(2026, 6, 6),
                    DepartureTime = new TimeSpan(6, 45, 0),
                    ArrivalTime = new TimeSpan(8, 30, 0),
                    CabinType = "Business",
                    AircraftType = "Boeing 737 MAX 9",
                    Emission = 140,
                    Price = 520m,
                    AirlineId = 3
                },
                new Flight
                {
                    FlightId = 4,
                    FlightCode = "WN720",
                    From = "San Francisco",
                    To = "Las Vegas",
                    Date = new DateTime(2026, 6, 6),
                    DepartureTime = new TimeSpan(13, 15, 0),
                    ArrivalTime = new TimeSpan(14, 45, 0),
                    CabinType = "Basic Economy",
                    AircraftType = "Boeing 737-700",
                    Emission = 120,
                    Price = 130m,
                    AirlineId = 4
                },
                new Flight
                {
                    FlightId = 5,
                    FlightCode = "DL330",
                    From = "Las Vegas",
                    To = "Chicago",
                    Date = new DateTime(2026, 6, 7),
                    DepartureTime = new TimeSpan(9, 0, 0),
                    ArrivalTime = new TimeSpan(13, 10, 0),
                    CabinType = "Economy",
                    AircraftType = "Airbus A320",
                    Emission = 200,
                    Price = 240m,
                    AirlineId = 1
                },
                new Flight
                {
                    FlightId = 6,
                    FlightCode = "UA999",
                    From = "Chicago",
                    To = "Miami",
                    Date = new DateTime(2026, 6, 7),
                    DepartureTime = new TimeSpan(15, 30, 0),
                    ArrivalTime = new TimeSpan(19, 0, 0),
                    CabinType = "Economy Plus",
                    AircraftType = "Boeing 737-800",
                    Emission = 210,
                    Price = 275m,
                    AirlineId = 2
                }
            );
        }
    }
}