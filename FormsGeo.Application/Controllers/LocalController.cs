using FormsGeo.Data.Context;
using FormsGeo.Service.Local.Handle;
using FormsGeo.Service.Local.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FormsGeo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public LocalController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LocalPostRequest request)
        {
            var LocalPostHandle = new LocalPostHandle(request, _context, _configuration);
            return await LocalPostHandle.Handle();
        }
    }
}
