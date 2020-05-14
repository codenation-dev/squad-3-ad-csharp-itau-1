using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILogService
    {
        LogViewModel Add(LogViewModel entity, string token);
        LogViewModel Get(int entityId);
        bool Update(LogViewModel entity);
        bool Delete(int entityId);
        PaginationViewModel<LogViewModel> SelectAll(int pageStart = 1, int itemsPerPage = 10);
        LogViewModel Add(LogViewModel logViewModel);
    }
}