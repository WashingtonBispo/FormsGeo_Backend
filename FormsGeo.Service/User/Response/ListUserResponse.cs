using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.User.Response
{
    public class ListUserResponse
    {
        public ListUserResponse(UserEntity user)
        {
            Email = user.Email;
            Name = user.Name;
            Status = user.Status;
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public EnUserStatus Status { get; set; }
    }
}
