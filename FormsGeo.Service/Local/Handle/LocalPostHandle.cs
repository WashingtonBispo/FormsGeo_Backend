using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Local.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Local.Handle
{
    public class LocalPostHandle
    {

        LocalPostRequest _FormPostRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public LocalPostHandle(LocalPostRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPostRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Handle()
        {
            FormEntity form = _context.Form.FirstOrDefault(x => x.idForm == _FormPostRequest.formId);

            if (form == null) return null;

            try
            {
                foreach (var geolocation in _FormPostRequest.geolocations)
                {
                    var Local = new LocalEntity
                    {
                        form = form,
                        radius = geolocation.radius,
                        longitude = geolocation.longitude,
                        latitude = geolocation.latitude
                    };
                    _context.Local.Add(Local);
                }

                await _context.SaveChangesAsync();
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
