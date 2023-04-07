using System.IdentityModel.Tokens.Jwt;
using System.Text;
using LetsCalc.Database.Models;
using Microsoft.IdentityModel.Tokens;

namespace LetsCalc.API.Helper;

public static class AuthService
{
    public static string GetToken(UserModel userModel, JwtSettings jwtSettings)
    {
        var claims = ClaimsService.GetClaims(userModel);
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.LifeTime),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


   
}