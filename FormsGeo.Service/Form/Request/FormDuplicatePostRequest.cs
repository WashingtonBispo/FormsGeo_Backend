using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormDuplicatePostRequest
    {
        [Required]
        [FromBody]
        public string formId { get; set; }
    }
}
