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

    }
}
