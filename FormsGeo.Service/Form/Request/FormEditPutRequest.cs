using FormsGeo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormEditPutRequest
    {
        [Required]
        [FromBody]
        public string formId { get; set; }

        [FromBody]
        public string? name { get; set; }

        [FromBody]
        public string? questions { get; set; }

        [FromBody]
        public string? linkConsent { get; set; }

        [FromBody]
        public string? description { get; set; }

        [FromBody]
        public string? finalMessage { get; set; }

        [FromBody]
        public bool? gatherEnd { get; set; }

        [FromBody]
        public bool? gatherPassage { get; set; }

        [FromBody]
        public string? icon { get; set; }

        [FromBody]
        public EnFormStatus? status { get; set; }
    }
}
