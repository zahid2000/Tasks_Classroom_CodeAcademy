using System.Text.Json.Serialization;

namespace HttpRequestApp.Models
{
    public class Commit
    {
        [JsonPropertyName("sha")]

        public string Sha { get; set; }
        [JsonPropertyName("url")]

        public string Url { get; set; }
    }
}
