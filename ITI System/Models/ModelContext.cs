using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITI_System.ViewModels;

namespace ITI_System.Models
{
    public class ModelContext:IdentityDbContext<ApplicationUser>
    {
        public ModelContext():base()
        {
            
        }

        public ModelContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ENGMARIAMMAHMOU;Initial Catalog=ITI_System;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<crsResult> crsResults { get; set; }
        public DbSet<RegisterUser> RegisterUser { get; set; } = default!;
        public DbSet<loginUserViewModel> loginUserViewModel { get; set; } = default!;
        public DbSet<ITI_System.ViewModels.RoleViewModel> RoleViewModel { get; set; } = default!;

    }
}
