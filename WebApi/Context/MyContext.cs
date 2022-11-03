using Microsoft.EntityFrameworkCore;
using WebApi.Models;

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
    }
}
