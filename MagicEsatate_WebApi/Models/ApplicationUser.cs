using Microsoft.AspNetCore.Identity;

namespace MagicEsatate_WebApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
