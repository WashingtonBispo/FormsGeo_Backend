using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FormsGeo.Domain.Enums;

namespace FormsGeo.Service.Form.Handle
{
    public class FormDuplicatePostHandle
    {
        FormDuplicatePostRequest _FormPostRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FormDuplicatePostHandle(FormDuplicatePostRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPostRequest = request;
            _context = context;
            _configuration = configuration;
        }
         
        public async Task<FormPostResponse> Handle()
        {
            FormEntity form = _context.Form.Include(f => f.Users).FirstOrDefault(x => x.idForm == _FormPostRequest.formId);

            if (form == null) return null;

            var formId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            
            try
            {
                var formDuplicate = new FormEntity
                {
                    idForm = formId,
                    name = form.name.ToLower(),
                    description = form.description,
                    questions = form.questions,
                    linkConsent = form.linkConsent,
                    numberQuestions = form.numberQuestions,
                    finalMessage = form.finalMessage,
                    createdAt = DateTime.UtcNow,
                    gatherEnd = form.gatherEnd,
                    gatherPassage = form.gatherPassage,
                    icon = form.icon,
                    status = EnFormStatus.Preview
                };

                formDuplicate.Users = new List<UserEntity>();
                foreach(var user in form.Users){
                    formDuplicate.Users.Add(user);
                }
                _context.Form.Add(formDuplicate);
                await _context.SaveChangesAsync();
                return new FormPostResponse { formId = formId };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
