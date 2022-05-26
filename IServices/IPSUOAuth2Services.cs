using DIIS.PersonApp.Models;

namespace DIIS.PersonApp.IServices
{
    public interface IPSUOAuth2Services
    {
        public string CallAuthorize();
        public Task<TokenInfo> CallTokenAsync(string code);
        // public Task RefreshTokenAsync();
        public Task<User> GetProfileByAccessTokenAsync(string accessToken);

        public Task<bool> SignOut();
    }
}
