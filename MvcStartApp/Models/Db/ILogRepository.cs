using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public interface ILogRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetLogs();
    }
}
