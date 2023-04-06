using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LetsCalc.API;

public static class AuthStartup
{
    public static void ConfigureJwtAuth(IServiceCollection services, IConfiguration configuration)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Token:SecretKey").Value));
        var audience = configuration.GetSection("Token:Issuer").Value;
        var issuer = configuration.GetSection("Token:Audience").Value;

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