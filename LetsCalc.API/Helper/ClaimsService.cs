using System.Security.Claims;
using LetsCalc.Database.Models;

namespace LetsCalc.API.Helper;

public static class ClaimsService
{
    public static Claim[] GetClaims(UserModel userModel)
    {
        var claims = new[]
        {
            new Claim("id", userModel.Id.ToString()),
            new Claim("role", userModel.Role.ToString())
        };

        return claims;
    }
}