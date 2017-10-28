using Newtonsoft.Json;

namespace Employees.DataModels.Models
{
    public class Employee
    {
        public int Id
        {
            get; set;
        }

        [JsonProperty("first_name")]
        public string FirstName
        {
            get; set;
        }

        [JsonProperty("last_name")]
        public string LastName
        {
            get; set;
        }

        [JsonProperty("team_id")]
        public int TeamId
        {
            get; set;
        }

        public string Client
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }
    }
}
