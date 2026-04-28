using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sem2.Data.Entities;

namespace Sem2.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<ModuleInstructor> ModuleInstructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");

            SeedRoles(builder);
        }
        public void SeedRoles(ModelBuilder builder)
        {
            List<IdentityRole<Guid>> identityRoles = [
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "Student" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Staff", NormalizedName = "STAFF" },
                ];

            
            builder.Entity<IdentityRole<Guid>>().HasData(identityRoles);
        }
    }
}
