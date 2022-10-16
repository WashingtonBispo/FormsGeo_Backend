using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using FormsGeo.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Commom.Auth
{
    public static class AuthUtils
    {
        public static string GenerateJWTToUser(UserEntity user, IConfiguration configuration)
        {
            var claims = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id.ToString())
            });

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                configuration.GetSection("AppSettings:Token").Value
                ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = cred
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
