using System.Text.Json;

namespace Group5Flight.Models
{
    public static class SessionHelper
    {
        // Store any object in session
        public static void Store<T>(this ISession session, string key, T data)
        {
            string json = JsonSerializer.Serialize(data);
            session.SetString(key, json);
        }

        // Retrieve object from session
        public static T? Retrieve<T>(this ISession session, string key)
        {
            var jsonData = session.GetString(key);

            if (string.IsNullOrEmpty(jsonData))
                return default;

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}