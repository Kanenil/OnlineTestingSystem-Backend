using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTestingSystem.Domain;
using OnlineTestingSystem.Domain.Common;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Presistence
{
    public class OnlineTestingDbContext: IdentityDbContext<UserEntity, RoleEntity, int,
        IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public OnlineTestingDbContext(DbContextOptions<OnlineTestingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.UserId)
                .IsRequired();
            });

            builder.Entity<UserEntity>()
                .HasIndex(x => x.Slug)
                .IsUnique();

            builder.Entity<CourseEntity>()
               .HasIndex(x => x.Slug)
               .IsUnique();


            builder.Entity<CourseUserEntity>(cu =>
            {
                cu.HasKey(b => new { b.UserId, b.CourseId });
            });


        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<CourseRoleEntity> CourseRoles { get; set; }
        public DbSet<CourseUserEntity> CourseUsers { get; set; }
    }
}
