using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRep _repo;
    public AuthController(IAuthRep repo)
    {
      _repo = repo;

    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password){
        //Validate request 

        username = username.ToLower();

        if(await _repo.UserInDB(username))
            return BadRequest("That username is already taken");

        var userToCreate = new User{
            Username = username
        };

        var createdUser = await _repo.Register(userToCreate, password);

        return StatusCode(201); 
    }
  }
}