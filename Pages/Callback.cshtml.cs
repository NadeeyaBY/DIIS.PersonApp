using DIIS.PersonApp.IServices;
using DIIS.PersonApp.Models;
using DIIS.PersonApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DIIS.PersonApp.Pages
{
    public class CallbackModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Code { get; set; }

        public IPSUOAuth2Services PSUOAuth2Services { get; set; }


        public CallbackModel(IPSUOAuth2Services OAuth2Services)
        {
            PSUOAuth2Services = OAuth2Services;
        }

        public async Task<ActionResult> OnGet()
        {
            TokenInfo tokenInfo = await PSUOAuth2Services.CallTokenAsync(Code);
            if (tokenInfo == null || tokenInfo.access_token == null)
            {
                return LocalRedirect(Url.Content("~/"));
            }
            Models.User user = await PSUOAuth2Services.GetProfileByAccessTokenAsync(tokenInfo.access_token);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.user_login),
                new Claim(ClaimTypes.NameIdentifier, user.description),
                new Claim(ClaimTypes.GivenName, user.displayname),
                new Claim(ClaimTypes.Email, user.user_email)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               new AuthenticationProperties()
               {
                   IsPersistent = true,
               });

            return LocalRedirect(Url.Content("~/"));
        }

    }
}
