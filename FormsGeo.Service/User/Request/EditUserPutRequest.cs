using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace FormsGeo.Service.User.Request
{
    public class EditUserPutRequest
    {
        [Required]
        [FromBody]
        public string Email { get; set; }

        [Required]
        [FromBody]
        public string Name { get; set; }

    }
}
