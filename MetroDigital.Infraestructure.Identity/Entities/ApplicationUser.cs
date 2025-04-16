using Microsoft.AspNetCore.Identity;

namespace MetroDigital.Infraestructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name;
        public required string LastName;
    }
}
