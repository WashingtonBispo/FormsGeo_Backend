using FormsGeo.Data.Context;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Form.Handle
{
    public class FormEditPutHandle
    {
        FormEditPutRequest _FormPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public FormEditPutHandle(FormEditPutRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPutRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Handle()
        {
            var Form = _context.Form.FirstOrDefault(x => x.idForm == _FormPutRequest.formId);

            if (!(Form != null)) return new StatusCodeResult(404);

            try
            {
                if (!string.IsNullOrEmpty(_FormPutRequest.name))
                    Form.name = _FormPutRequest.name.ToLower();

                if (!string.IsNullOrEmpty(_FormPutRequest.description))
                    Form.description = _FormPutRequest.description;

                if (!string.IsNullOrEmpty(_FormPutRequest.questions))
                    Form.questions = _FormPutRequest.questions;

                if (!string.IsNullOrEmpty(_FormPutRequest.linkConsent))
                    Form.linkConsent = _FormPutRequest.linkConsent;

                if (!string.IsNullOrEmpty(_FormPutRequest.finalMessage))
                    Form.finalMessage = _FormPutRequest.finalMessage;

                if (!string.IsNullOrEmpty(_FormPutRequest.icon))
                    Form.icon = _FormPutRequest.icon;

                if (_FormPutRequest.gatherEnd != null)
                    Form.gatherEnd = Convert.ToBoolean(_FormPutRequest.gatherEnd);

                if (_FormPutRequest.gatherPassage != null)
                    Form.gatherPassage = Convert.ToBoolean(_FormPutRequest.gatherPassage);

                if (_FormPutRequest.status != null)
                    Form.status =  (EnFormStatus) _FormPutRequest.status;

                Form.updatedAt = DateTime.UtcNow;

                _context.Form.Update(Form);
                await _context.SaveChangesAsync();
                
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }

        }
    }
}
