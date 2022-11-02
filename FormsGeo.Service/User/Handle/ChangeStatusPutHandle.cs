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
    public class ChangeStatusPutHandle
    {
        ChangeStatusPutRequest _userPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public ChangeStatusPutHandle(ChangeStatusPutRequest request, DataContext context, IConfiguration configuration)
        {
            _userPutRequest = request;
            _context = context;
            _configuration = configuration;

            _userPutRequest.Email = _userPutRequest.Email.ToLower();
        }

        public async Task<IActionResult> Handle()
        {
            try
            {
                UserEntity user = _context.User.FirstOrDefault(x => x.Email.ToLower() == _userPutRequest.Email);

                if (user == null) return new StatusCodeResult(404);

                user.Status = _userPutRequest.Status;

                _context.User.Update(user);
                await _context.SaveChangesAsync();


                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
