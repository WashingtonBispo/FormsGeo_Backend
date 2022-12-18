using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Answer.Request
{
    public class AnswerPostRequest
    {
        [Required]
        [FromBody]
        public string answer { get; set; }

        [Required]
        [FromBody]
        public int typeAnswer { get; set; }

        [Required]
        [FromBody]
        public string idParticipante { get; set; }

        [Required]
        [FromBody]
        public string idForm { get; set; }
    }
}
