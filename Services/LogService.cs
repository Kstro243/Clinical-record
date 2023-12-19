using emz.Data;
namespace emz.Services
{
    public interface ILogService
    {
        Task<Log> Create(Log hdToCreate);
    }
    public class LogService : ILogService
    {
        private readonly DataContext _context;
        public LogService(DataContext context)
        {
            _context = context;
        }
        public async Task<Log> Create(Log logToCreate)
        {
            if(_context.Log == null)
            {
                return new Log(){};
            }

            var newLog = new Log()
            {
                CreationDate = DateTime.Now,
                Activity = logToCreate.Activity,
                UserId = logToCreate.UserId
            };
            await _context.Log.AddAsync(newLog);
            await _context.SaveChangesAsync();

            return newLog;
        }
    }
}