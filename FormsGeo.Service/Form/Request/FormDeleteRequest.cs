using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormDeleteRequest
    {
        [Required]
        [FromQuery]
        public string formId { get; set; }
    }
}
