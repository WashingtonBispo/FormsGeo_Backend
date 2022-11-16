using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormListGetRequest
    {
        [FromQuery]
        public string? email { get; set; }

        [FromQuery]
        public string? filter { get; set; }
    }
}
