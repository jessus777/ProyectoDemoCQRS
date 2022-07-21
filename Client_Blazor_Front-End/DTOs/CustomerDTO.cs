using Enums;
using System.Text.Json.Serialization;
namespace DTOs
{
    public class CustomerDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("secondName")]
        public string SecondName { get; set; }

        [JsonPropertyName("firstLastName")]
        public string FirstLastName { get; set; }

        [JsonPropertyName("secondLastName")]
        public string SecondLastName { get; set; }

        [JsonPropertyName("rfc")]
        public string RFC { get; set; }

        [JsonPropertyName("registartionDate")]
        public DateTime RegistartionDate { get; set; }

        [JsonPropertyName("genderType")]
        public GenderType GenderType { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
