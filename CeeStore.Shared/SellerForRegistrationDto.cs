using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.Shared
{
    public record SellerForRegistrationDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; init; }

        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; init; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; init; }
    }
}
