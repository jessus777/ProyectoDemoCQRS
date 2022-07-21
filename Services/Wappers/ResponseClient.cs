using System.Text.Json.Serialization;

namespace Services.Wappers
{
    public class ResponseClient<T>
    {
        public ResponseClient()
        {

        }
        [JsonPropertyName("succeeded")]
        public bool Succeeded { get; set; } = false;
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
