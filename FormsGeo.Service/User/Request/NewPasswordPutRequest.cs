using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.User.Request
{
    public class NewPasswordPutRequest
    {
        [Required]
        [FromBody]
        public string Email { get; set; }

        [Required]
        [FromBody]
        public string oldPassword { get; set; }

        [Required]
        [FromBody]
        public string newPassword { get; set; }
    }
}
