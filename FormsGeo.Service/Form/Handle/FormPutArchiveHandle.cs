using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Domain.Enums;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FormsGeo.Service.Form.Handle
{
    public class FormPutArchiveHandle
    {
        FormPutArchiveRequest _FormPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FormPutArchiveHandle(FormPutArchiveRequest request, DataContext context, IConfiguration configuration)
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
                form.isArchiverd = _FormPutRequest.archived;
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

