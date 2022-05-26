using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DIIS.PersonApp.Pages.User
{
    public partial class Profile
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthStateTask { get; set; }

        public IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();
        string UserName = string.Empty;
        string Email = string.Empty;
        string NameThai = string.Empty;
        string NameEng = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                var name = authState.User.Identity.Name;
                _claims = user.Claims;
                UserName = user.FindFirst(c => c.Type == ClaimTypes.Name).Value;
                Email = user.FindFirst(c => c.Type == ClaimTypes.Email).Value;
                NameThai = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
                NameEng = user.FindFirst(c => c.Type == ClaimTypes.GivenName).Value;
            }
        }
    }
}