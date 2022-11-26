using FormsGeo.Data.Context;
using FormsGeo.Service.Form.Handle;
using FormsGeo.Service.Form.Request;
using FormsGeo.Service.Form.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormsGeo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public FormController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<FormPostResponse> Post([FromBody] FormPostRequest request)
        {
            var FormPostHandle = new FormPostHandle(request, _context, _configuration);
            return await FormPostHandle.Handle();
        }

        [HttpPost("Duplicate")]
        [AllowAnonymous]
        public async Task<FormPostResponse> Post([FromBody] FormDuplicatePostRequest request)
        {
            var FormPostHandle = new FormDuplicatePostHandle(request, _context, _configuration);
            return await FormPostHandle.Handle();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<FormGetResponse> get([FromQuery] FormIdGetRequest request)
        {
            var FormGetHandle = new FormIdGetHandle(request, _context, _configuration);
            return await FormGetHandle.Handle();
        }

        [HttpGet("List")]
        [AllowAnonymous]
        public async Task<List<FormGetResponse>> get([FromQuery] FormListGetRequest request)
        {
            var FormGetHandle = new FormListGetHandle(request, _context, _configuration);
            return await FormGetHandle.Handle();
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] FormEditPutRequest request)
        {
            var FormPutHandle = new FormEditPutHandle(request, _context, _configuration);
            return await FormPutHandle.Handle();
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromQuery] FormDeleteRequest request)
        {
            var FormDeleteHandle = new FormDeleteHandle(request, _context, _configuration);
            return await FormDeleteHandle.Handle();
        }

    }
}
