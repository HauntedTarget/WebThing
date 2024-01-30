using System.ComponentModel.DataAnnotations;
using ValidationPrac.Validators;

namespace ValidationPrac.Models
{
    [Address]
    public class Validation
    {
        [Required(ErrorMessage = "No Name Provided!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "No Age Provided!")]
        [Range(5, int.MaxValue, ErrorMessage = "Too Young!")]
        public int? Age { get; set; }

        public string? Street, City, State, ZipCode;

        public Validation() { }

        public Validation(string name, int age, string street, string city, string state, string zipCode)
        {
            Name = name;
            Age = age;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
