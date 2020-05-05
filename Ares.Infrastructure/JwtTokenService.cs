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
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Name, user.UserId)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;

        }
    }
}
