using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Entities.Client.User;
using QFlick.Domain.Entities.Common;
using QFlick.Domain.Entities.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        #region -users to the application
        public DbSet<AppUser> User { get; set; }
        public DbSet<BusinessUsers> Staff { get; set; }
        #endregion


        #region -roles/permissions and menus
        public DbSet<AppRole> Role { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppPermissions> Permissions { get; set; }
        public DbSet<AppRolePermissions> RolePermissions { get; set; }
        public DbSet<AppMenuItem> MenuItem { get; set; }
        #endregion


        #region -queue
        public DbSet<QueueDetail> QueueDetail { get; set; }
        #endregion

        #region -business
        public DbSet<BusinessServices> Business { get; set; }
        public DbSet<BusinessCategory> BusinessCategory { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ensure the roles are populated every database
            modelBuilder.Entity<AppRole>()
                .HasData(
                    new AppRole { Id = 1, Name = "business-admin", Description = "Full administrative access to manage business settings, staff accounts, and organization data.", IsActive = true },
                    new AppRole { Id = 2, Name = "business-user", Description = "Staff member access to manage day-to-day operations and customer queues.", IsActive = true },
                    new AppRole { Id = 3, Name = "user", Description = "Standard customer access for viewing services and managing individual bookings.", IsActive = true }
            );

            modelBuilder.Entity<BusinessCategory>().HasData(
                    new BusinessCategory { Id = 1, CategoryName = "Healthcare & Clinics" },
                    new BusinessCategory { Id = 2, CategoryName = "Banking & Financial Services" },
                    new BusinessCategory { Id = 3, CategoryName = "Government & Public Services" },
                    new BusinessCategory { Id = 4, CategoryName = "Retail & Grocery" },
                    new BusinessCategory { Id = 5, CategoryName = "Restaurants & Cafes" },
                    new BusinessCategory { Id = 6, CategoryName = "Saloons & Spas" }
            );

            modelBuilder.Entity<AppUserRole>()
                .HasKey(ur => new { ur.RoleId, ur.UserId });

            modelBuilder.Entity<AppRolePermissions>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });


        }

    }
}
