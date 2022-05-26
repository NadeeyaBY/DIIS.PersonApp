using DIIS.PersonApp.Models;

namespace DIIS.PersonApp.IServices
{
    public interface IUserService
    {
        Task<CurrentUser> GetCurrentUserAsync();
    }
}
