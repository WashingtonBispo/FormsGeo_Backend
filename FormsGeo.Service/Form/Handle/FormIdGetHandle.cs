using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Form.Handle
{
    public class FormIdGetHandle
    {
        FormIdGetRequest _FormGetRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FormIdGetHandle(FormIdGetRequest request, DataContext context, IConfiguration configuration)
        {
            _FormGetRequest = request;
            _context = context;
            _configuration = configuration;

        }

        public async Task<FormGetResponse> Handle()
        {
            try
            {
               FormEntity form = _context.Form.FirstOrDefault(x => x.idForm == _FormGetRequest.formId);

               return new FormGetResponse(form);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
