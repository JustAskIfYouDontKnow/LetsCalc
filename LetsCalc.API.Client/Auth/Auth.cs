using System.ComponentModel.DataAnnotations;

namespace LetsCalc.API.Client.Auth;

public class Auth
{
    [Required]
    public string Login { get; set; }

    [Required]
    [StringLength(36, MinimumLength = 5)]
    public string Password { get; set; }


    public class Response
    {
        [Required]
        public string Token { get; }
            
        public Response(string token)
        {
            Token = token;
        }
    }
}