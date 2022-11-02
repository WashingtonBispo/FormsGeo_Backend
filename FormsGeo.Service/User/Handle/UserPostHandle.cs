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
using System.Security.Cryptography;
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
        
        public UserPostHandle(UserPostRequest request, DataContext context, IConfiguration configuration)
        {
            _userPostRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserResponse> Handle()
        {
            AuthUtils.ValidateUserInfor(_userPostRequest.Email, _userPostRequest.Password);

            var password = AuthUtils.PasswordCrypt(_userPostRequest.Password);

            var user = new UserEntity { Email = _userPostRequest.Email.ToLower(), Name = _userPostRequest.Name.ToLower(), Password = password };
            user.Status = EnUserStatus.Ativo;
            user.isAdmin = false;

            await _context.AddAsync(user);
            _context.SaveChanges();

            var JWT = AuthUtils.GenerateJWTToUser(user, _configuration);

            return new UserResponse { JWT = JWT };
        }
    }
}
