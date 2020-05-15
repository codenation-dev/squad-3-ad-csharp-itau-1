using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILogService
    {
        LogViewModel Add(LogViewModel entity, string token);
        LogViewModel Get(int entityId);
        bool Update(LogViewModel entity);
        bool Delete(int entityId);
        PaginationViewModel<OutLogViewModel> SelectAll(string? search, string idsEnv = "1", int order = 1, int pageStart = 1, int itemsPerPage = 10);
    }
}
