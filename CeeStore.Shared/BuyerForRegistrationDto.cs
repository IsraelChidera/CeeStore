using System.ComponentModel.DataAnnotations;

namespace CeeStore.Shared
{
    public record BuyerForRegistrationDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; init; }

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
