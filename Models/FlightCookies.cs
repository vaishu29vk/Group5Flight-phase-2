namespace Group5Flight.Models
{
    public class FlightCookies
    {
        private const string CookieKey = "flightSelections";
        private const char Separator = '|';

        private IRequestCookieCollection? _readCookies;
        private IResponseCookies? _writeCookies;

        // Constructor for reading cookies
        public FlightCookies(IRequestCookieCollection cookies)
        {
            _readCookies = cookies;
        }

        // Constructor for writing cookies
        public FlightCookies(IResponseCookies cookies)
        {
            _writeCookies = cookies;
        }

        // Get selected flight IDs from cookie
        public string[] GetSelectedIds()
        {
            var value = _readCookies?[CookieKey];

            if (string.IsNullOrEmpty(value))
                return Array.Empty<string>();

            return value.Split(Separator);
        }

        // Save selected IDs into cookie – 14-day expiry per spec
        public void SetSelectedIds(List<string> ids)
        {
            string data = string.Join(Separator, ids);

            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(14)
            };

            RemoveSelectedIds();    // delete old cookie first
            _writeCookies?.Append(CookieKey, data, options);
        }

        // Remove cookie completely
        public void RemoveSelectedIds()
        {
            _writeCookies?.Delete(CookieKey);
        }
    }
}
