﻿using FormsGeo.Data.Context;
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
    public class UserDeleteHandle
    {
        UserDeleteRequest _userDeleteRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserDeleteHandle(UserDeleteRequest request, DataContext context, IConfiguration configuration)
        {
            _userDeleteRequest = request;
            _context = context;
            _configuration = configuration;

            _userDeleteRequest.Email = _userDeleteRequest.Email.ToLower();
        }

        public async Task<ActionResult> Handle()
        {
            try
            {
                UserEntity user = _context.User.FirstOrDefault(x => x.Email.ToLower() == _userDeleteRequest.Email) ;

                if(user != null)
                {
                    _context.User.Remove(user);
                    await _context.SaveChangesAsync();
                    return new StatusCodeResult(200);
                }
                else
                {
                    return new StatusCodeResult(404);
                }
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
