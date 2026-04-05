using System.ComponentModel.DataAnnotations;

namespace Group5Flight.Models
{
    public class Airline
    {
        // Primary key
        public int AirlineId { get; set; }

        // Airline name
        [Required(ErrorMessage = "Airline name is required.")]
        public string Name { get; set; } = "";

        // Stores image file name
        public string? ImageName { get; set; }

        // Navigation property (one airline → many flights)
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}