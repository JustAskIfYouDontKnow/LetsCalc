using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LetsCalc.API;

public static class AuthStartup
{
    public static void ConfigureJwtAuth(IServiceCollection services, IConfiguration configuration)
    {
        var key = configuration.GetSection("Token:SecretKey").Value;
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        var audience = configuration.GetSection("Token:Audience").Value;
        var issuer = configuration.GetSection("Token:Issuer").Value;
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuerSigningKey = true,
                    };
                }
            );
    }
}