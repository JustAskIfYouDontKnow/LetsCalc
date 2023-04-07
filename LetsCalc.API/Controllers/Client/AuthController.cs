using System.Security.Claims;
using LetsCalc.API.Client.Auth;
using LetsCalc.API.Helper;
using LetsCalc.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LetsCalc.API.Controllers.Client;

public class AuthController : AbstractController
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;

    private readonly ILogger<AbstractController> _logger;
    
    public AuthController(IUserRepository userRepository, IOptions<JwtSettings> optionsAccessor, ILogger<AbstractController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
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


        var claims = ClaimsService.GetClaims(userModel);
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        
        _logger.LogDebug("Token was generated for user id {id}: {token}", userModel.Id, token);
        
        return Ok(new Auth.Response(token));
    }
}


