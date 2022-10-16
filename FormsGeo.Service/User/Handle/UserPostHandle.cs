using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<UserPostResponse> Handle()
        {
            var user = new UserEntity { Email = _userPostRequest.Email, Name = _userPostRequest.Name, Password = _userPostRequest.Password };

            await _context.AddAsync(user);
            _context.SaveChanges();

            var JWT = AuthUtils.GenerateJWTToUser(user, _configuration);

            return new UserPostResponse { Id = user.Id, JWT = JWT };
        }
    }
}
