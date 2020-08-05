using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace robsonteste.Models
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("login")]
        public string login { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("html_url")]
        public string html_url { get; set; }
        [JsonPropertyName("avatar_url")]
        public string avatar_url { get; set; }

    }
}
