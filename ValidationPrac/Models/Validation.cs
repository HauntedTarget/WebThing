namespace ValidationPrac.Models
{
    public class Validation
    {
        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? Street, City, State;

        public int? ZipCode { get; set; }

        public bool Valid { get; set; }

        public Validation(string name, int age, string street, string city, string state, int zipCode)
        {
            Name = name;
            Age = age;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Valid = true;
        }

        public Validation(string name, int age, string street, string city, string state, int zipCode, bool valid)
        {
            Name = name;
            Age = age;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Valid = valid;
        }
    }
}
