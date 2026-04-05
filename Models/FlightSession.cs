namespace Group5Flight.Models
{
    public class FlightSession
    {
        private const string FromKey    = "fromCity";
        private const string ToKey      = "toCity";
        private const string DateKey    = "selectedDate";
        private const string CabinKey   = "cabinType";
        private const string AirlineKey = "airlineName";

        private readonly ISession _session;

        public FlightSession(ISession session)
        {
            _session = session;
        }

        // FROM
        public void SetActiveFrom(string value) =>
            _session.SetString(FromKey, value);
        public string GetActiveFrom() =>
            _session.GetString(FromKey) ?? "";

        // TO
        public void SetActiveTo(string value) =>
            _session.SetString(ToKey, value);
        public string GetActiveTo() =>
            _session.GetString(ToKey) ?? "";

        // DATE
        public void SetActiveDate(string value) =>
            _session.SetString(DateKey, value);
        public string GetActiveDate() =>
            _session.GetString(DateKey) ?? "";

        // CABIN
        public void SetActiveCabin(string value) =>
            _session.SetString(CabinKey, value);
        public string GetActiveCabin() =>
            _session.GetString(CabinKey) ?? "";

        // AIRLINE
        public void SetActiveAirline(string value) =>
            _session.SetString(AirlineKey, value);
        public string GetActiveAirline() =>
            _session.GetString(AirlineKey) ?? "";
    }
}
