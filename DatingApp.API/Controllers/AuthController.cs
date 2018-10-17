using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //^ This takes care of writng request and reading from the data storage.
  //a.k.a  the display of "200 good requset" or "400 Bad request" and so on.
  //Can infer where the data is coming from 
  public class AuthController : ControllerBase
  {
    private readonly IAuthRep _repo;
    private readonly IConfiguration _config;
    public AuthController(IAuthRep repo, IConfiguration config)
    {
      _repo = repo;
      _config = config;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserToReg userToReg){
                                              //^ Our DTO(Data Transfer Object), reg template
                                              //^Will infer user.n and pass.w from the body
        userToReg.Username = userToReg.Username.ToLower();

        if(await _repo.UserInDB(userToReg.Username))
            return BadRequest("That username is already taken");

        var userToCreate = new User{
            Username = userToReg.Username
        };

        var createdUser = await _repo.Register(userToCreate, userToReg.Password);

        return StatusCode(201); 
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserToLog userToLog){
      var userFromRepo = await _repo.Login(userToLog.Username, userToLog.Password);

      if(userFromRepo == null)
        return Unauthorized();

      //token containing user id and username
      //with this you don't have a to go to your db 
      //With what you've stored in here
      var claims = new[]{
        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, userFromRepo.Username)
        //CMD . Sercurity claims
      };
      //Hashed nonreadable in token
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
      //Sign

      var tokenDesciptor = new SecurityTokenDescriptor{
        Subject = new ClaimsIdentity(claims),
      }
    }
  }
}