using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore; 

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
                            //^Will inherit from this class
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Value> MyProperty {get; set;}
        
    }
}
