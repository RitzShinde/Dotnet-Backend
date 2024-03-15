using AngularPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AngularPractice.DBContext
{
    public class MyDBContext : DbContext
    {

        public MyDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Todo> Todos { get; set; }

        
    }
}
