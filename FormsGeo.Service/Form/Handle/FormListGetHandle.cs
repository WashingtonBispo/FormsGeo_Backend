using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

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
                    formsDB = _context.Form.Include(f => f.Users).Where(x => x.Users.Where(x => x.Email == _FormGetRequest.email).Any() && x.deletedAt == null);
                else
                    formsDB = _context.Form.Include(f => f.Users).AsQueryable();

                if (_FormGetRequest.archived)
                    formsDB = formsDB.Where(x => x.status == Domain.Enums.EnFormStatus.Arquivado );
                else
                    formsDB = formsDB.Where(x => x.status != Domain.Enums.EnFormStatus.Arquivado);

                if (!string.IsNullOrEmpty(_FormGetRequest.filter))
                    formsDB = formsDB.Where(x => x.name.ToLower().Contains(_FormGetRequest.filter) || x.Users.FirstOrDefault(u => u.Email.Contains(_FormGetRequest.filter)) != null);

                formsDB = formsDB.OrderBy(f => f.name);

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
