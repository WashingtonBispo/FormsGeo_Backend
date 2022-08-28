using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.User.Request
{
    public class UserPostRequest
    {
        /// <summary>
        /// Name of user
        /// </summary>
        [Required]
        [FromBody]
        public string Name { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        [FromBody]
        public string Email { get; set; }

        /// <summary>
        /// Password of user
        /// </summary>
        [Required]
        [FromBody]
        public string Password { get; set; }
    }
}
