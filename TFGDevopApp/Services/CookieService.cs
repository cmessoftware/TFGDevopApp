using System.Security.Claims;
using TFGDevopsApp.Core.Models;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Services
{
    public class CookieService
    {
        public async Task<ResultMessage<UserCreateResponseDto>> Login(string name)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
             {
                 new Claim(ClaimTypes.NameIdentifier, name)
             }, "auth");
            ClaimsPrincipal claims = new ClaimsPrincipal(claimsIdentity);
            //await HttpContext.SignInAsync(claims);
            return new ResultMessage<UserCreateResponseDto>()
            {
                Data = new UserCreateResponseDto()
                {
                    Name = name,
                    UserName = claims?.Identity?.Name
                }
            };
        }
    }
}