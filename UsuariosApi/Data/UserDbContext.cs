using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
        {

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
