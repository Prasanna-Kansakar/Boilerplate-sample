using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AngularTest.Authorization.Roles;
using AngularTest.Authorization.Users;
using AngularTest.MultiTenancy;

namespace AngularTest.EntityFrameworkCore
{
    public class AngularTestDbContext : AbpZeroDbContext<Tenant, Role, User, AngularTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public AngularTestDbContext(DbContextOptions<AngularTestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Student>().Navigation(x => x.StudentClasses).AutoInclude();*/
            base.OnModelCreating(modelBuilder);
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
