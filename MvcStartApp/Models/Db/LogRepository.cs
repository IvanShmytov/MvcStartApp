using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext _context;

        public LogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
            {
                await _context.Requests.AddAsync(request);
            }
            await _context.SaveChangesAsync();
        }

        public Task<Request[]> GetLogs()
        {
            throw new System.NotImplementedException();
        }
    }
}
