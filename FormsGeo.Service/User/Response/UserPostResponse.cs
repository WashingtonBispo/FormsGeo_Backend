using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.User.Response
{
    public class UserPostResponse
    {
        /// <summary>
        /// Name of user
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
