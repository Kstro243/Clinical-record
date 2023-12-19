using emz.Data;
namespace emz.Services
{
    public interface ISessionService
    {
        Task<Session> Create(Session sessionToCreate);
        Task<bool> Delete(int sessionId);
    }
    public class SessionService : ISessionService
    {
        private readonly DataContext _context;
        public SessionService(DataContext context)
        {
            _context = context;
        }
        public async Task<Session> Create(Session sessionToCreate)
        {
            if(_context.Session == null)
            {
                return new Session(){};
            }

            var newSession = new Session()
            {
                CreationDate = DateTime.Now,
                IpAddress = sessionToCreate.IpAddress,
                UserId = sessionToCreate.UserId
            };
            await _context.Session.AddAsync(newSession);
            await _context.SaveChangesAsync();

            return newSession;
        }
        public async Task<bool> Delete(int sessionId)
        {
            if(_context.Session == null)
            {
                return false;
            }

            var sessionInDb = await _context.Session.FindAsync(sessionId);
            if(sessionInDb == null)
            {
                return false;
            }
            _context.Session.Remove(sessionInDb);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}