using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 999999
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin, "Admin123#");

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 999999, Name = "admin", NormalizedName = "ADMIN" }
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
