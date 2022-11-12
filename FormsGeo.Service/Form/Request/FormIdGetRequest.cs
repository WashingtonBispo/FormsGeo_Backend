using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormIdGetRequest
    {
        [Required]
        [FromQuery]
        public string formId { get; set; }
    }
}
