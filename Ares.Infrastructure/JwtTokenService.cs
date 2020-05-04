using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ares.Infrastructure
{

    public class AppSettings
    {
        public string SecretKey { get; set; }
    }

    // dotnet add package System.IdentityModel.Tokens.Jwt
    public class JwtTokenService : ITokenService
    {
        private readonly AppSettings appSettings;

        public JwtTokenService(IOptions<AppSettings> options)
        {
            this.appSettings = options.Value;
        }

        public string Create(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
         
            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescription);

            string token = tokenHandler.WriteToken(securityToken);

            return token;

        }
    }
}
