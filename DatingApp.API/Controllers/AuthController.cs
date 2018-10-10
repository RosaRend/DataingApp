using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController
  {
    private readonly IAuthRep _repo;
    public AuthController(IAuthRep repo)
    {
      _repo = repo;

    }
    // [HttpPost("register")]
    // public async Task<IActionResult> Register(string username, string password){

    // }
  }
}