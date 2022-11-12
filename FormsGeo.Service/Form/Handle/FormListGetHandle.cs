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

            _FormGetRequest.email = _FormGetRequest.email.ToLower();
        }

        public async Task<List<FormGetResponse>> Handle()
        {
            try
            {

                if (!string.IsNullOrEmpty(_FormGetRequest.email))
                {
                    var Forms = _context.User.Where(x => x.Email ==_FormGetRequest.email).SelectMany(x => x.Forms).ToList();

                    return Forms.Select(x => new FormGetResponse(x)).ToList();

                }
                else
                    return _context.Form.Select(x => new FormGetResponse(x)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
