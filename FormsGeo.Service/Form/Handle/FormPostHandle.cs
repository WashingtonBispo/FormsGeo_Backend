using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Form.Handle
{
    public class FormPostHandle
    {
        FormPostRequest _FormPostRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public FormPostHandle(FormPostRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPostRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<FormPostResponse> Handle()
        {
            var formId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var Form = new FormEntity
            {
                idForm = formId,
                name = _FormPostRequest.name.ToLower(),
                description = _FormPostRequest.description,
                questions = "",
                linkConsent = _FormPostRequest.linkConsent,
                finalMessage = _FormPostRequest.finalMessage,
                createdAt = DateTime.UtcNow,
                gatherEnd = _FormPostRequest.gatherEnd,
                gatherPassage = _FormPostRequest.gatherPassage,
                icon = _FormPostRequest.icon,
                status = EnFormStatus.Preview,
                geolocations = "{'onPass':'', 'onGather':[]}"
            };

            Form.Users = new List<UserEntity>();

            UserEntity User = _context.User.FirstOrDefault(x => x.Email == _FormPostRequest.email.ToLower());
            Form.Users.Add(User);

            _context.Form.Add(Form);
            await _context.SaveChangesAsync();

            return new FormPostResponse { formId = formId };
        }
    }
}

