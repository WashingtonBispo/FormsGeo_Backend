using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Domain.Entities
{
    public class AnswerEntity
    {
        public int answerId { get; set; }
        public string answer { get; set; }
        public string geolocation { get; set; }
        public int? typeAnswer { get; set; }
        public string idParticipante { get; set; }
        public FormEntity Form { get; set; }
    }
}
