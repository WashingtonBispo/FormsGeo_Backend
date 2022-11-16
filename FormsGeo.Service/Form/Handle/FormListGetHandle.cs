using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Form.Handle
{
    public class FormListGetHandle
    {
        FormListGetRequest _FormGetRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FormListGetHandle(FormListGetRequest request, DataContext context, IConfiguration configuration)
        {
            _FormGetRequest = request;
            _context = context;
            _configuration = configuration;
            
            if(!string.IsNullOrEmpty(_FormGetRequest.email))
                _FormGetRequest.email = _FormGetRequest.email.ToLower();

            if (!string.IsNullOrEmpty(_FormGetRequest.filter))
                _FormGetRequest.filter = _FormGetRequest.filter.ToLower();
        }

        public async Task<List<FormGetResponse>> Handle()
        {
            try
            {
                List<FormGetResponse> forms;
                IQueryable<FormEntity> formsDB;
                if (!string.IsNullOrEmpty(_FormGetRequest.email))
                    formsDB = _context.User.Where(x => x.Email == _FormGetRequest.email).SelectMany(x => x.Forms);
                else
                    formsDB = _context.Form.AsQueryable();

                if (!string.IsNullOrEmpty(_FormGetRequest.filter))
                    formsDB = formsDB.Where(x => x.name.ToLower().Contains(_FormGetRequest.filter));
                        
                forms = formsDB.Select(x => new FormGetResponse(x)).ToList();

                return forms;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
