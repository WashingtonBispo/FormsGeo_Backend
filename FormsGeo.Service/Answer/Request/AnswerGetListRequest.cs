using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Answer.Request
{
    public class AnswerGetListRequest
    {
        [FromQuery]
        [Required]
        public string formId { get; set; }
    }
}
