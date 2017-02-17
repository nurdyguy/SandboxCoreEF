using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SandboxCoreEF.Models;

namespace SandboxCoreEF.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users", schema: "dbo");
                entity.Property(e => e.Id).HasColumnName("UserId");

            });

            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "Roles", schema: "dbo");
                entity.Property(e => e.Id).HasColumnName("RoleId");

            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims", "dbo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Id).HasColumnName("UserClaimId");

            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins", "dbo");
                entity.Property(e => e.UserId).HasColumnName("UserId");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims", "dbo");
                entity.Property(e => e.Id).HasColumnName("RoleClaimId");
                entity.Property(e => e.RoleId).HasColumnName("RoleId");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles", "dbo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.RoleId).HasColumnName("RoleId");

            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens", "dbo");
                entity.Property(e => e.UserId).HasColumnName("UserId");

            });



        }
    }
}
