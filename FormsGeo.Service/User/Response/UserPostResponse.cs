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
        /// Id of user
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// auth token
        /// </summary>
        [Required]
        public string JWT { get; set; }
    }
}
