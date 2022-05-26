using DIIS.PersonApp.Models;

namespace DIIS.PersonApp.IServices
{
    public interface IProjectService
    {
        Task<NoticeType[]?> GetProjectNoticeAsync();
        Task<ActivitiesType[]?> GetActivitiesAsync();
        Task<ListItemDataType[]?> GetFakeListAsync(int count = 0);
        Task<NoticeItem[]?> GetNoticesAsync();
    }
}
