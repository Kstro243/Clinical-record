using emz.Data;
using Microsoft.EntityFrameworkCore;

namespace emz.Services
{
    public interface ITypeOfIdentificationService
    {
        Task<List<TypeOfIdentification>> GetAll();
    }
    public class TypeOfIdentificationService : ITypeOfIdentificationService
    {
        private readonly DataContext _context;
        public TypeOfIdentificationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TypeOfIdentification>> GetAll()
        {
            if(_context.TypeOfIdentification == null)
            {
                return new List<TypeOfIdentification>(new List<TypeOfIdentification>());
            }

            var TypeOfIdentificationToReturn = await _context.TypeOfIdentification.ToListAsync();

            return new List<TypeOfIdentification>(TypeOfIdentificationToReturn);
        }
    }
}