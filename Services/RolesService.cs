using emz.Data;
using Microsoft.EntityFrameworkCore;

namespace emz.Services
{
    public interface IRolesService
    {
        Task<List<Roles>> GetRoles();
    }
    public class RolesService : IRolesService
    {
        private readonly DataContext _context;
        public RolesService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Roles>> GetRoles()
        {
            if(_context.Roles == null)
            {
                return new List<Roles>(new List<Roles>());
            }

            var rolesToReturn = await _context.Roles.ToListAsync();

            return new List<Roles>(rolesToReturn);
        }
    }
}