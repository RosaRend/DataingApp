using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
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
    public async Task<IActionResult> Register(UserToReg userToReg){
                                              //^ Our DTO(Data Transfer Object), reg template
                                              //^Will infer user.n and pass.w from the body
        //Validate request 

        userToReg.Username = userToReg.Username.ToLower();

        if(await _repo.UserInDB(userToReg.Username))
            return BadRequest("That username is already taken");

        var userToCreate = new User{
            Username = userToReg.Username
        };

        var createdUser = await _repo.Register(userToCreate, userToReg.Password);

        return StatusCode(201); 
    }
  }
}