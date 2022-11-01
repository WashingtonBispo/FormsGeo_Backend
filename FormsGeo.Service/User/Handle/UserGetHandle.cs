using FormsGeo.Data.Context;
using FormsGeo.Service.Commom.Auth;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.Extensions.Configuration;


namespace FormsGeo.Service.User.Handle
{
    public class UserGetHandle
    {
        UserGetRequest _userGetRequest { get; set; }
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private string regexEmail = @"^[a-z0-9]+@[a-z]+\.[a-z]{2,3}$";

        public UserGetHandle(UserGetRequest request, DataContext context, IConfiguration configuration)
        {
            _userGetRequest = request;
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserResponse> Handle()
        {
            AuthUtils.ValidateUserInfor(_userGetRequest.Email, _userGetRequest.Password);

            var password = AuthUtils.PasswordCrypt(_userGetRequest.Password);

            var user = _context.User.Where(u => u.Email == _userGetRequest.Email && u.Password == password).FirstOrDefault();

            if (user == null)
                return null;

            var JWT = AuthUtils.GenerateJWTToUser(user, _configuration);

            return new UserResponse { JWT = JWT };
        }
    }
}
