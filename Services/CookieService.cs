using System.Security.Claims;
using TFGDevopsApp1.Core.Models;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.Services
{
    public class CookieService
    {
        public async Task<Result<UserCreateResponseDto>> Login(string name)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
             {
                 new Claim(ClaimTypes.NameIdentifier, name)
             }, "auth");
            ClaimsPrincipal claims = new ClaimsPrincipal(claimsIdentity);
            //await HttpContext.SignInAsync(claims);
            return new Result<UserCreateResponseDto>()
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