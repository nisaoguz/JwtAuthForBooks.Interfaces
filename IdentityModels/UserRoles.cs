using Microsoft.AspNetCore.Identity;

namespace JwtAuthForBooks.IdentityModels
{
    public class UserRoles : IdentityRole<string>
    {
        public UserRoles() // Parametresiz yapıcı ekleyin
        {
        }

        public UserRoles(string roleName) : base(roleName)
        {
        }

        public const string Admin = "Admin";
        public const string User = "User";

        public string Description { get; set; } // Rolün açıklaması
    }
}
