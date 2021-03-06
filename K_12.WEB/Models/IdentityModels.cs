﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace K_12.WEB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("DisplayName", this.DisplayName));
            // Add custom user claims here
            return userIdentity;
        }

        public string DisplayName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("K_12Connection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins", "dbo");

        }


    }


}