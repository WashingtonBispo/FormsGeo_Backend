using FormsGeo.Data.Context;
using FormsGeo.Service.Answer.Handle;
using FormsGeo.Service.Answer.Request;
using FormsGeo.Service.Answer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormsGeo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AnswerController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] AnswerPostRequest request)
        {
            var AnswerPostHandle = new AnswerPostHandle(request, _context, _configuration);
            return await AnswerPostHandle.Handle();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<AnswerResponse>> Get([FromQuery] AnswerGetListRequest request)
        {
            var AnswerGetListHandle = new AnswerGetListHandle(request, _context, _configuration);
            return await AnswerGetListHandle.Handle();
        }

    }
}
