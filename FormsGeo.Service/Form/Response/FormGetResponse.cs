using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Service.Form.Response
{
    public class FormGetResponse
    {
        public FormGetResponse(FormEntity user)
        {
            idForm = user.idForm;
            questions = user.questions;
            name = user.name;
            linkConsent = user.linkConsent;
            description = user.description;
            finalMessage = user.finalMessage;
            createdAt = user.createdAt;
            gatherEnd = user.gatherEnd;
            gatherPassage = user.gatherPassage;
            icon = user.icon;
            status = user.status;
        }

        public string idForm { get; set; }
        public string questions { get; set; }
        public string name { get; set; }
        public string linkConsent { get; set; }
        public string description { get; set; }
        public string finalMessage { get; set; }
        public DateTime createdAt { get; set; }
        public bool gatherEnd { get; set; }
        public bool gatherPassage { get; set; }
        public string icon { get; set; }
        public EnFormStatus status { get; set; }

    }
}
