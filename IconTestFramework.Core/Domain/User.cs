using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IconTestFramework.Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }

    public class UserResponse
    {
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        public List<User> Data { get; set; }
    }
}
