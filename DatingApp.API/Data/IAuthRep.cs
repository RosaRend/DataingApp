using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRep
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<User> UserInDB(string username);
    }
}