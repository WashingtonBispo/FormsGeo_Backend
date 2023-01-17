using FormsGeo.Domain.Enums;

namespace FormsGeo.Domain.Entities
{
    public class FormEntity
    {
        public string idForm { get; set; }
        public string questions { get; set; }
        public string name { get; set; }
        public int? numberQuestions { get; set; }
        public string linkConsent { get; set; }
        public string description { get; set; }
        public string geolocations { get; set; }
        public string finalMessage { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public bool gatherEnd { get; set; }
        public bool gatherPassage { get; set; }
        public string icon { get; set; }
        public EnFormStatus status { get; set; }

        public ICollection<UserEntity> Users { get; set; }
        public ICollection<AnswerEntity> Answers { get; set; }

    }
}
