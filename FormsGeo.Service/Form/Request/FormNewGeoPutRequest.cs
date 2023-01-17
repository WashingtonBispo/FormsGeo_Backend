using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Form.Request
{
    public class FormNewGeoPutRequest
    {
        [Required]
        [FromBody]
        public List<geolocation> geolocations { get; set; }
        public class geolocation
        {
            public string formId { get; set; }
            public string idParticipante { get; set; }
            public decimal latitude { get; set; }
            public decimal longitude { get; set; }
            public DateTime date { get; set; }
        }
    }
}
