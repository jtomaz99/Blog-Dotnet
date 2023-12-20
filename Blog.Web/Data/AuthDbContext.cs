using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Create Roles

            var adminRoleId = "2172126B-1E88-4560-A982-823269129EE8";
            var userRoleId = "F3186F79-4F5E-482C-94E4-86A3B3B3E969";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Admin
            var adminId = "7BBE49F3-C123-4E92-9A35-0F11090A0B92";
            var adminUser = new IdentityUser
            {
                UserName = "jtomaz99",
                Email = "jtomaz1999@gmail.com",
                NormalizedEmail = "jtomaz1999@gmail.com".ToUpper(),
                NormalizedUserName = "jtomaz99".ToUpper(),
                Id = adminId,
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "7288C93F-3492-401E-8A51-8709A2388014");

            builder.Entity<IdentityUser>().HasData(adminUser);

            // Add roles to admin
            var superAdmin = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = adminId,
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdmin);
        }
    }
}
