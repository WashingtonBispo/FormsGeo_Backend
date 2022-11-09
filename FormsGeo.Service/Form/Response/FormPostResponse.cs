using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Response
{
    public class FormPostResponse
    {
        [Required]
        public string formId { get; set; }
    }
}
