using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.Form.Request
{
    public class FormPutArchiveRequest
    {
        [Required]
        [FromBody]
        public string formId { get; set; }

        [Required]
        [FromBody]
        public bool archived { get; set; }
    }
}
