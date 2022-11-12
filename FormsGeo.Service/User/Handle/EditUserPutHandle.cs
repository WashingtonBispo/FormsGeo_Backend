using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace FormsGeo.Service.User.Handle
{
    public class EditUserPutHandle
    {
        EditUserPutRequest _userPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public EditUserPutHandle(EditUserPutRequest request, DataContext context, IConfiguration configuration)
        {
            _userPutRequest = request;
            _context = context;
            _configuration = configuration;

            if (!string.IsNullOrEmpty(_userPutRequest.Email))
                _userPutRequest.Email = _userPutRequest.Email.ToLower();
        }

        public async Task<UserResponse> Handle()
        {
            try
            {
                UserEntity user = _context.User.FirstOrDefault(x => x.Email.ToLower() == _userPutRequest.Email);

                if(user == null) throw new Exception("User not found");

                user.Name = _userPutRequest.Name;

                _context.User.Update(user);
                await _context.SaveChangesAsync();

                var JWT = AuthUtils.GenerateJWTToUser(user, _configuration);

                return new UserResponse { JWT = JWT };
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
