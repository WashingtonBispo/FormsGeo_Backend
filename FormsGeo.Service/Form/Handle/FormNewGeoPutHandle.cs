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
    public class FormNewGeoPuthandle
    {
        public class geolocationJson
        {
            public GeolocationEntity onFinish { get; set; }
            public List<GeolocationEntity> onGather { get; set; }
        }

        FormNewGeoPutRequest _FormPutRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public FormNewGeoPuthandle(FormNewGeoPutRequest request, DataContext context, IConfiguration configuration)
        {
            _FormPutRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Handle()
        {
            foreach (var geolocation in _FormPutRequest.geolocations)
            {
                AnswerEntity answer = _context.Answer.FirstOrDefault(a => a.idParticipante == geolocation.idParticipante && a.FormId == geolocation.formId);


                try
                {
                    geolocationJson? json = JsonSerializer.Deserialize<geolocationJson>(answer.geolocation);
                    json.onGather.Add(new GeolocationEntity { Latitude = geolocation.latitude,Longitude=geolocation.longitude,Time=geolocation.date });
                    answer.geolocation = JsonSerializer.Serialize(json);
                    _context.Answer.Update(answer);
                }
                catch (Exception ex)
                {
                    return new StatusCodeResult(400);
                }
            }
            await _context.SaveChangesAsync();
            return new StatusCodeResult(200);

        }
    }
}
