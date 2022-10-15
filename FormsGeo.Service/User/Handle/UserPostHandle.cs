using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
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
        public UserPostHandle(UserPostRequest request, DataContext context)
        {
            _userPostRequest = request;
            _context = context;
        }

        public async Task<UserPostResponse> Handle()
        {
            var userToPost = new UserEntity { Email = _userPostRequest.Email, Name = _userPostRequest.Name, Password = _userPostRequest.Password };

            await _context.AddAsync(userToPost);
            _context.SaveChanges();

            return new UserPostResponse { Id = userToPost.Id };
        }
    }
}
