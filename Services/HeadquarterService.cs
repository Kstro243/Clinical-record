using emz.Data;
using Microsoft.EntityFrameworkCore;

namespace emz.Services
{
    public interface IHeadquarterService
    {
        Task<List<Headquarter>> GetAll();
        Task<Headquarter> Get(int hqId);
        Task<Headquarter> Create(Headquarter hdToCreate);
        Task<Headquarter> Edit(Headquarter hdToCreate);
        Task<Headquarter> Inactivate(int hdId);
    }
    public class HeadquarterService : IHeadquarterService
    {
        private readonly DataContext _context;
        public HeadquarterService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Headquarter>> GetAll()
        {
            if(_context.Headquarter == null)
            {
                return new List<Headquarter>(new List<Headquarter>(){});
            }

            var hqToReturn = await _context.Headquarter.ToListAsync();

            return new List<Headquarter>(hqToReturn);
        }
        public async Task<Headquarter> Get(int hdId)
        {
            if(_context.Headquarter == null)
            {
                return new Headquarter(){};
            }

            var hqToReturn = await _context.Headquarter.FindAsync(hdId) ?? new Headquarter(){};

            return hqToReturn;
        }
        public async Task<Headquarter> Create(Headquarter hqToCreate)
        {
            if(_context.Headquarter == null)
            {
                return new Headquarter(){};
            }

            var newHq = new Headquarter()
            {
                Name = hqToCreate.Name,
                PhoneNumber = hqToCreate.PhoneNumber,
                Address = hqToCreate.Address,
                City = hqToCreate.City,
                IsActive = hqToCreate.IsActive,
            };
            await _context.Headquarter.AddAsync(newHq);
            await _context.SaveChangesAsync();

            return newHq;
        }
        
        public async Task<Headquarter> Edit(Headquarter hqToEdit)
        {
            if(_context.Headquarter == null)
            {
                return new Headquarter();
            }

            var hdInDb = await _context.Headquarter.FindAsync(hqToEdit);
            if(hdInDb == null)
            {
                return new Headquarter();
            }

            hdInDb.Name = hqToEdit.Name;
            hdInDb.PhoneNumber = hqToEdit.PhoneNumber;
            hdInDb.Address = hqToEdit.Address;
            hdInDb.City = hqToEdit.City;
            hdInDb.IsActive = hqToEdit.IsActive;


            _context.Headquarter.Update(hdInDb);
            await _context.SaveChangesAsync();

            return hdInDb;
        }
        
        public async Task<Headquarter> Inactivate(int hdId)
        {
            if(_context.Headquarter == null)
            {
                return new Headquarter();
            }

            var hdInDb = await _context.Headquarter.FindAsync(hdId);
            if(hdInDb == null)
            {
                return new Headquarter();
            }

            hdInDb.IsActive = false;


            _context.Headquarter.Update(hdInDb);
            await _context.SaveChangesAsync();

            return hdInDb;
        }
    }
}