using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore; 

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
                            //^Will inherit from this class
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        //to create a constructor use ctor then tab
                                            //^ type               ^chain it base ctor
        public DbSet<Value> Values {get; set;}
        public DbSet<User> Users {get; set;}
        
    }
}
