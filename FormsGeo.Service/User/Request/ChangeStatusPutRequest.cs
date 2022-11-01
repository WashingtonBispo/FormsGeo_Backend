using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.User.Request
{
    public class ChangeStatusPutRequest
    {
        [Required]
        [FromBody]
        public string Email { get; set; }

        [Required]
        [FromBody]
        public int Status { get; set; }
    }
}
