using System.Text.Json.Serialization;

namespace HttpRequestApp.Models
{
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("commit")]

        public Commit Commit { get; set; }
        [JsonPropertyName("protected")]

        public bool Protected { get; set; }
    }
}
