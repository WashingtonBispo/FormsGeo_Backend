using FormsGeo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.Answer.Response
{
    public class AnswerResponse
    {
        public int answerId { get; set; }
        public string answer { get; set; }
        public string geolocation { get; set; }
        public int? typeAnswer { get; set; }

        public AnswerResponse(AnswerEntity answer)
        {
            answerId = answer.answerId;
            this.answer = answer.answer;
            geolocation = answer.geolocation;
            typeAnswer = answer.typeAnswer;

        }
    }
}
