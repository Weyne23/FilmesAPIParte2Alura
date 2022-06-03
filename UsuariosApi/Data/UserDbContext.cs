using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> opts, IConfiguration configuration) : base(opts)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 999999
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 999999, Name = "admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 999998, Name = "regular", NormalizedName = "REGULAR" }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 999999, UserId = 999999 }
                );
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityUserLogin<int>>(ent =>
        //    {
        //        ent.Property(x => x.LoginProvider).HasMaxLength(110);
        //        ent.Property(x => x.ProviderKey).HasMaxLength(127);
        //    });

        //    builder.Entity<IdentityUserRole<int>>(ent =>
        //    {
        //        ent.Property(x => x.UserId).HasMaxLength(127);
        //        ent.Property(x => x.RoleId).HasMaxLength(127);
        //    });

        //    builder.Entity<IdentityUserToken<int>>(ent =>
        //    {
        //        ent.Property(x => x.UserId).HasMaxLength(110);
        //        ent.Property(x => x.LoginProvider).HasMaxLength(110);
        //        ent.Property(x => x.LoginProvider).HasMaxLength(110);
        //    });
        //}
    }
}
