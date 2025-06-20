using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensiones
{
    public static class ServiceAuthenticateApplication
    {
        public static IServiceCollection AddServicesAuthenticate(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes(configuration["TokenKeySecurity"])),
                           ValidateIssuer = false,
                           ValidateAudience = false,
                       };
                   });
            return services;
        }
    }
}
