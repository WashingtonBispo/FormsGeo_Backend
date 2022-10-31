using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.Extensions.Configuration;
using System;

namespace FormsGeo.Service.User.Handle
{
    public class ListUserGetHandle
    {

        ListUserGetRequest _userGetRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public ListUserGetHandle(ListUserGetRequest request, DataContext context, IConfiguration configuration)
        {
            _userGetRequest = request;
            _context = context;
            _configuration = configuration;

            if(!string.IsNullOrEmpty(_userGetRequest.filter))
                _userGetRequest.filter = _userGetRequest.filter.ToLower();
        }

        public async Task<List<ListUserResponse>> Handle()
        {
            List<UserEntity> userList;
            if (string.IsNullOrEmpty(_userGetRequest.filter))
                userList = _context.User.ToList();
            else
                userList = _context.User.Where(user => (user.Email.ToLower().Contains(_userGetRequest.filter) || user.Name.ToLower().Contains(_userGetRequest.filter)) && user.isAdmin==false).ToList();

            var convertedList = userList.Select(x => new ListUserResponse(x)).ToList();
            return convertedList;
        }
    }
}
