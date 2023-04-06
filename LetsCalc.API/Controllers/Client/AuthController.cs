
using LetsCalc.API.Client.Auth;
using LetsCalc.API.Helper;
using LetsCalc.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LetsCalc.API.Controllers.Client;

public class AuthController : AbstractController
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;

    public AuthController(IUserRepository userRepository, IOptions<JwtSettings> optionsAccessor)
    {
        _userRepository = userRepository;
        _jwtSettings = optionsAccessor.Value;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] Auth request)
    {
        var login = request.Login.ToLower();
        
        var userModel = await _userRepository.GetOne(login, request.Password);

        if (userModel is null)
        {
            return BadRequest("User or password is wrong");
        }
        
        var token = AuthService.GetToken(userModel, _jwtSettings);

        return Ok(new Auth.Response(token));
    }


    
}


