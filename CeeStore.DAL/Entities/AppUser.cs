using Microsoft.AspNetCore.Identity;

namespace CeeStore.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator Guid(AppUser v)
        {
            throw new NotImplementedException();
        }
    }
}
