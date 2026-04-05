using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5Flight.Models
{
    public class Flight
    {
        // Primary Key
        public int FlightId { get; set; }

        // Basic details
        [Required(ErrorMessage = "Flight code is required.")]
        public string FlightCode { get; set; } = "";

        [Required(ErrorMessage = "From city is required.")]
        public string From { get; set; } = "";

        [Required(ErrorMessage = "To city is required.")]
        public string To { get; set; } = "";

        // Schedule - no [Required] on value types (DateTime/TimeSpan can never be null)
        public DateTime Date { get; set; }

        // TimeSpan binds correctly from <input type="time"> (HH:mm format)
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        // Flight configuration
        [Required(ErrorMessage = "Cabin type is required.")]
        public string CabinType { get; set; } = "";

        [Required(ErrorMessage = "Aircraft type is required.")]
        public string AircraftType { get; set; } = "";

        // Environmental + pricing
        public int Emission { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        // Foreign Key
        public int AirlineId { get; set; }

        // Navigation Property
        public Airline? Airline { get; set; }
    }
}
