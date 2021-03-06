﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity

{
    /// <summary>
    /// This class is intented to make custom classes so that i can map my AspNetUsers on the player table. 
    /// Changed the id so it is an int instead of a string.
    /// </summary>
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, BoldQuizUserLogin, BoldQuizUserRole, BoldQuizUserClaim>
    {
        public string user_type {get; set;}
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