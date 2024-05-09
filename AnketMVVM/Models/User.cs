
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AnketMVVM.Models
{
    public class User
    {
     

        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? FatherName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }



        public User Clone() => new User { Name = Name, Surname = Surname, FatherName = FatherName,Email = Email,PhoneNumber = PhoneNumber,DateTime = DateTime };

        public override string ToString() => $"Name: {Name} Surname: {Surname} FatherName: {FatherName} Email: {Email} PhoneNumber {PhoneNumber} Date: {DateTime}\n";

 
    }
}
