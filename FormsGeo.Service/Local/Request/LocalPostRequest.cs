using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.Local.Request
{
    public class LocalPostRequest
    {
        public class geolocation
        {
            [Required]
            [FromBody]
            public int radius { get; set; }

            [Required]
            [FromBody]
            public decimal longitude { get; set; }

            [Required]
            [FromBody]
            public decimal latitude { get; set; }
        }

        [Required]
        [FromBody]
        public string formId { get; set; }

        [Required]
        [FromBody]
        public List<geolocation> geolocations { get; set; }

    }
}
