using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.User.Request
{
    public class UserGetRequest
    {
        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        [FromQuery]
        public string Email { get; set; }

        /// <summary>
        /// Password of user
        /// </summary>
        [Required]
        [FromQuery]
        public string Password { get; set; }
    }
}
