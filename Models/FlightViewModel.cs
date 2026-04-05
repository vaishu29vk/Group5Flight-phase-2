namespace Group5Flight.Models
{
    public class FlightViewModel
    {
        // Data collections
        public IEnumerable<Flight> Flights { get; set; } = new List<Flight>();
        public IEnumerable<Airline> Airlines { get; set; } = new List<Airline>();

        // Dropdown data (cities)
        public List<string> FromCities { get; set; } = new List<string>();
        public List<string> ToCities { get; set; } = new List<string>();

        // Active filter values (bound from form POST / session)
        public string ActiveFrom { get; set; } = "";
        public string ActiveTo { get; set; } = "";
        public string ActiveDate { get; set; } = "";
        public string ActiveCabin { get; set; } = "";
        public string ActiveAirline { get; set; } = "";

        // Predefined cabin types per spec
        public static List<string> CabinOptions { get; } = new List<string>
        {
            "Basic Economy",
            "Economy",
            "Economy Plus",
            "Business"
        };

        // Alias so Airlines area view can use either name
        public static List<string> CabinTypes => CabinOptions;

        // Predefined aircraft types per spec
        public static List<string> AircraftOptions { get; } = new List<string>
        {
            "Airbus A319",
            "Airbus A320",
            "Airbus A321",
            "Airbus A321neo",
            "Boeing 737-700",
            "Boeing 737-800",
            "Boeing 737 MAX 8",
            "Boeing 737 MAX 9"
        };

        // Alias so Airlines area view can use either name
        public static List<string> AircraftTypes => AircraftOptions;

        // Selection count for badge (driven from cookie)
        public int SelectionCount { get; set; }

        // Used for edit mode in Airlines area
        public Flight? EditingFlight { get; set; }
    }
}
