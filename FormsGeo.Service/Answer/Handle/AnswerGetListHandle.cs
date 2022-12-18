using FormsGeo.Data.Context;
using FormsGeo.Domain.Entities;
using FormsGeo.Service.Answer.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FormsGeo.Service.Answer.Response;

namespace FormsGeo.Service.Answer.Handle
{
    public class AnswerGetListHandle
    {
        AnswerGetListRequest _AnswerGetListRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AnswerGetListHandle(AnswerGetListRequest request, DataContext context, IConfiguration configuration)
        {
            _AnswerGetListRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<AnswerResponse>> Handle()
        {

            try
            {
                List<AnswerResponse> answers = _context.Form.Include(f => f.Answers).FirstOrDefault(f => f.idForm == _AnswerGetListRequest.formId).Answers.Select(a => new AnswerResponse(a)).ToList();
                return answers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
