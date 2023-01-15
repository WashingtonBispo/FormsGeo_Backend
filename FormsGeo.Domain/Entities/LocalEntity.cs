using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Domain.Entities
{
    public class LocalEntity { 
        public string idLocal { get; set; }
        public int radius { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public FormEntity form { get; set; }

    }
}
