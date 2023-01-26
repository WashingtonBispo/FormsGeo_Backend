﻿using FormsGeo.Domain.Entities;
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
        public FormGetResponse(FormEntity form)
        {
            idForm = form.idForm;
            questions = form.questions;
            name = form.name;
            linkConsent = form.linkConsent;
            numberQuestions = form.numberQuestions;
            description = form.description;
            finalMessage = form.finalMessage;
            createdAt = form.createdAt;
            gatherEnd = form.gatherEnd;
            gatherPassage = form.gatherPassage;
            icon = form.icon;
            status = form.status;
            geolocations = form.geolocations;
            author = form.Users.FirstOrDefault().Email;
            isArchiverd = form.isArchiverd;
            if(form.Answers != null)
                numberAnswers = form.Answers.Count;
        }

        public string idForm { get; set; }
        public string questions { get; set; }
        public string name { get; set; }
        public int? numberQuestions { get; set; }
        public string linkConsent { get; set; }
        public string description { get; set; }
        public string finalMessage { get; set; }
        public DateTime createdAt { get; set; }
        public bool gatherEnd { get; set; }
        public bool gatherPassage { get; set; }
        public string icon { get; set; }
        public string geolocations { get; set; }
        public string? author { get; set; }
        public EnFormStatus status { get; set; }
        public Boolean isArchiverd { get; set; }

        public int numberAnswers { get; set; }

    }
}
