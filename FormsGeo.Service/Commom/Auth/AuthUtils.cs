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
using FormsGeo.Service.User.Request;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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
                new Claim(ClaimTypes.Role, user.isAdmin ? "Admin" : "Researcher"),
                new Claim("status", user.Status.ToString())
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

        public static void ValidateUserInfor (string email, string password)
        {
            string regexEmail = @"^[a-z0-9]+@[a-z]+\.[a-z]{2,3}$";

            Match matchEmail = Regex.Match(email, regexEmail, RegexOptions.IgnoreCase);
            if (!matchEmail.Success)
            {
                throw new HttpRequestException("O Email está em um formato inválido!", null, System.Net.HttpStatusCode.BadRequest);
            }

            if (password.Length < 8)
            {
                throw new HttpRequestException("A Senha precisa ter no mínimo 8 caracteres!", null, System.Net.HttpStatusCode.BadRequest);
            }
        }

        public static string PasswordCrypt (string password)
        {
            var sha = SHA256.Create();

            var bytes = Encoding.Default.GetBytes(password);

            var hashedPassword = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}
