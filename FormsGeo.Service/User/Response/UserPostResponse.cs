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
        /// auth token
        /// </summary>
        [Required]
        public string JWT { get; set; }
    }
}
