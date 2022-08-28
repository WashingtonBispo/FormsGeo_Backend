using FormsGeo.Data.Context;
using FormsGeo.Service.User.Handle;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormsGeo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserPostResponse> Post([FromBody] UserPostRequest request)
        {
            var userPostHande = new UserPostHandle(request, _context);
            return await userPostHande.Handle();
        }
    }
}
