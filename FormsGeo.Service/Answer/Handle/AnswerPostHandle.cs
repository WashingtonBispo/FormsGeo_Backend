using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Answer.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FormsGeo.Service.Answer.Handle
{
    public class AnswerPostHandle
    {
        AnswerPostRequest _AnswerPostRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AnswerPostHandle(AnswerPostRequest request, DataContext context, IConfiguration configuration)
        {
            _AnswerPostRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Handle()
        {
            AnswerEntity answer = new AnswerEntity
            {
                answer = _AnswerPostRequest.answer,
                typeAnswer = _AnswerPostRequest.typeAnswer,
                idParticipante = _AnswerPostRequest.idParticipante,
                geolocation = ""
            };

            FormEntity form =  _context.Form.FirstOrDefault(x => x.idForm == _AnswerPostRequest.idForm);
            if (form == null) return new StatusCodeResult(404);

            answer.Form = form;

            try
            {
                _context.Answer.Add(answer);
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

