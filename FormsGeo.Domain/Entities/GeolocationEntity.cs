using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Domain.Entities
{
    public class GeolocationEntity
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Time { get; set; }
    }
}
