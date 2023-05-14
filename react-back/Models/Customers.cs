using System;
using System.Text.Json.Serialization;

namespace react_back.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("first")]
        public string? First { get; set; }

        [JsonPropertyName("last")]
        public string? Last { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("create_at")]
        public DateTime Create_at { get; set; }
    }
}
