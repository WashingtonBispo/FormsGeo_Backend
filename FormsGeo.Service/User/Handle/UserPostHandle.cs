using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormsGeo.Service.User.Handle
{
    public class UserPostHandle
    {
        UserPostRequest _userPostRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        string regexEmail = @"^[a-z0-9]+@[a-z]+\.[a-z]{2,3}$";
        public UserPostHandle(UserPostRequest request, DataContext context, IConfiguration configuration)
        {
            _userPostRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserPostResponse> Handle()
        {
            Match matchEmail = Regex.Match(_userPostRequest.Email, regexEmail, RegexOptions.IgnoreCase);
            if (!matchEmail.Success)
            {  
                throw new HttpRequestException("O Email está em um formato inválido!", null, System.Net.HttpStatusCode.BadRequest);
            }

            if (_userPostRequest.Password.Length<8)
            {
                throw new HttpRequestException("A Senha precisa ter no mínimo 8 caracteres!", null, System.Net.HttpStatusCode.BadRequest);
            }

            var user = new UserEntity { Email = _userPostRequest.Email, Name = _userPostRequest.Name, Password = _userPostRequest.Password };
            user.Status = EnUserStatus.Ativo;
            user.isAdmin = false;

            await _context.AddAsync(user);
            _context.SaveChanges();

            var JWT = AuthUtils.GenerateJWTToUser(user, _configuration);

            return new UserPostResponse { JWT = JWT };
        }
    }
}
