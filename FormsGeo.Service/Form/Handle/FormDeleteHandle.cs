using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Form.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Form.Handle
{
    public class FormDeleteHandle
    {
        FormDeleteRequest _FormPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FormDeleteHandle(FormDeleteRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPutRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Handle()
        {
            FormEntity form = _context.Form.FirstOrDefault(x => x.idForm == _FormPutRequest.formId);

            if (form == null) return new StatusCodeResult(404);

            try
            {
                _context.Form.Remove(form);
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