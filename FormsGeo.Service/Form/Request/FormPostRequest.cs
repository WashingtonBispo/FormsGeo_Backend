using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.Form.Request
{
    public class FormPostRequest
    {
        [Required]
        [FromBody]
        public string email { get; set; }

        [Required]
        [FromBody]
        public string name { get; set; }

        [Required]
        [FromBody]
        public string linkConsent { get; set; }

        [Required]
        [FromBody]
        public string description { get; set; }

        [Required]
        [FromBody]
        public string finalMessage { get; set; }

        [Required]
        [FromBody]
        public bool gatherEnd { get; set; }

        [Required]
        [FromBody]
        public bool gatherPassage { get; set; }

        [Required]
        [FromBody] 
        public string icon { get; set; }

    }
}

