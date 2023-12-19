using emz.Data;

namespace emz.Services
{
    public interface ITokenService
    {
        Task<bool> IsValid();
    }
    public class TokenService : ITokenService
    {
        private readonly DataContext _context;
        public TokenService(DataContext context)
        {
            _context = context;
        }

        public Task<bool> IsValid()
        {
            if(_context.Token == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}