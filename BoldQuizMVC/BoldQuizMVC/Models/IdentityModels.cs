using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;

namespace BoldQuizMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int,BoldQuizUserLogin, BoldQuizUserRole, BoldQuizUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add BoldQuiz user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, BoldQuizRole, int, BoldQuizUserLogin, BoldQuizUserRole, BoldQuizUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }
        
    }
    public class BoldQuizUserRole : IdentityUserRole<int> { }
    public class BoldQuizUserClaim : IdentityUserClaim<int> { }
    public class BoldQuizUserLogin : IdentityUserLogin<int> { }

    public class BoldQuizRole : IdentityRole<int, BoldQuizUserRole>
    {
        public BoldQuizRole() { }
        public BoldQuizRole(string name) { Name = name; }
    }

    public class BoldQuizUserStore : UserStore<ApplicationUser, BoldQuizRole, int, BoldQuizUserLogin, BoldQuizUserRole, BoldQuizUserClaim>
    {
        public BoldQuizUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class BoldQuizRoleStore : RoleStore<BoldQuizRole, int, BoldQuizUserRole>
    {
        public BoldQuizRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}