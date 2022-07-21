using Enums;

namespace Models
{
    public class CustomerEntity
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string RFC { get; set; }
        public DateTime RegistartionDate { get; set; }
        public GenderType GenderType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
