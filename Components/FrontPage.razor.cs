using DIIS.PersonApp.IServices;
using DIIS.PersonApp.Services;
using Microsoft.AspNetCore.Components;

namespace DIIS.PersonApp.Components
{
    partial class FrontPage
    {
        [Inject] protected NavigationManager? NavigationManager { get; set; }

        [Inject] protected IPSUOAuth2Services? OAuth2Services { get; set; }
        public void SignIn()
        {
            string url = OAuth2Services.CallAuthorize();
            NavigationManager.NavigateTo(url);
        }
    }
}
