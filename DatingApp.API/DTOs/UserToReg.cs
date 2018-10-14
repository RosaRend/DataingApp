using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserToReg
    {
        [Required]
        //^ 'cmd + .' system annottions to get it to work
        public string Username {get; set;}
        //need to check if the user is actually 
        //passing in a username and passord
        // ALL Areas blank registers that user
        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be more than 8 characters long.")]
        public string Password {get; set;}
    }
    //Required fixes the problem
}