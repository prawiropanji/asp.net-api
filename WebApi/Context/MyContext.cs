using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebAppMVC.Models;

namespace WebApi.Context
{
    public class MyContext : DbContext
    {
     

        public MyContext(DbContextOptions<MyContext> dbContextOptions ) 
            : base( dbContextOptions )
        {

        }

        public DbSet<Division> divisions { get; set; }
        public DbSet<Departement> departements { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
