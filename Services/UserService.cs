using emz.Data;
using emz.Responses;
using Microsoft.EntityFrameworkCore;

namespace emz.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> Get(int userId);
        Task<UserResponse> Create(User userToCreate);
        Task<User> Edit(User userToCreate);
        Task<User> Inactivate(int userId);
    }
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            if
            (
                _context.User == null ||
                _context.UsersHeadquarters == null ||
                _context.UsersRoles == null
            )
            {
                return new List<User>(new List<User>(){});
            }

            var userToReturn = await _context.User.ToListAsync();
            var listOfUsersToReturn = new List<User>(){};
            foreach (var user in userToReturn)
            {
                var userToList = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    TypeOfIdentificationId = user.TypeOfIdentificationId,
                    IdentificationNumber = user.IdentificationNumber,
                    IsActive = user.IsActive,
                    UsersRoles = await _context.UsersRoles.Where(userR => userR.UserId == user.Id).ToListAsync(),
                    UsersHeadquarters = await _context.UsersHeadquarters.Where(userR => userR.UserId == user.Id).ToListAsync()
                };
                listOfUsersToReturn.Add(userToList);
            }

            return new List<User>(listOfUsersToReturn);
        }
        public async Task<User> Get(int userId)
        {
            if
            (
                _context.User == null ||
                _context.UsersHeadquarters == null ||
                _context.UsersRoles == null
            )
            {
                return new User(){};
            }

            var userToReturn = await _context.User.FindAsync(userId) ?? new User(){};

            var userToList = new User()
            {
                FirstName = userToReturn.FirstName,
                LastName = userToReturn.LastName,
                Email = userToReturn.Email,
                TypeOfIdentificationId = userToReturn.TypeOfIdentificationId,
                IdentificationNumber = userToReturn.IdentificationNumber,
                IsActive = userToReturn.IsActive,
                UsersRoles = await _context.UsersRoles.Where(userToReturnR => userToReturnR.UserId == userToReturn.Id).ToListAsync(),
                UsersHeadquarters = await _context.UsersHeadquarters.Where(userToReturnR => userToReturnR.UserId == userToReturn.Id).ToListAsync()
            };

            return userToList;
        }
        public async Task<UserResponse> Create(User userToCreate)
        {
            if
            (
                _context.User == null ||
                _context.UsersHeadquarters == null ||
                _context.UsersRoles == null ||
                _context.TypeOfIdentification == null
            )
            {
                return new UserResponse(){};
            }

            byte[] passwordToBytes = System.Text.Encoding.UTF8.GetBytes(userToCreate.Password);
            string bytesToEncondedPassword = Convert.ToBase64String(passwordToBytes, Base64FormattingOptions.InsertLineBreaks);

            var newUser = new User()
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Password = bytesToEncondedPassword,
                TypeOfIdentificationId = userToCreate.TypeOfIdentificationId,
                IdentificationNumber = userToCreate.IdentificationNumber,
                IsActive = userToCreate.IsActive,
            };
            await _context.User.AddAsync(newUser);

            if(userToCreate.UsersHeadquarters == null)
            {
                return new UserResponse();
            }
            foreach (var uHq in userToCreate.UsersHeadquarters)
            {
                var userHq = new UsersHeadquarters() 
                {
                    User = newUser,
                    HeadquarterId = uHq.HeadquarterId
                };

                await _context.UsersHeadquarters.AddAsync(userHq);
            }

            if(userToCreate.UsersRoles == null)
            {
                return new UserResponse();
            }
            foreach (var uR in userToCreate.UsersRoles)
            {
                var userRole = new UsersRoles() 
                {
                    User = newUser,
                    RolesId = uR.RolesId
                };

                await _context.UsersRoles.AddAsync(userRole);
            }

            await _context.SaveChangesAsync();

            var userToReturn = new UserResponse()
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                TypeOfIdentificationName = (await _context.TypeOfIdentification.FindAsync(userToCreate.TypeOfIdentificationId))?.Name ?? string.Empty,
                IdentificationNumber = userToCreate.IdentificationNumber,
                IsActive = userToCreate.IsActive
            };

            return userToReturn;
        }
        
        public async Task<User> Edit(User userToEdit)
        {
            if(
                _context.User == null ||
                _context.UsersHeadquarters == null ||
                _context.UsersRoles == null
            )
            {
                return new User();
            }

            var userInDb = await _context.User.FindAsync(userToEdit);
            if(userInDb == null)
            {
                return new User();
            }

            userInDb.FirstName = userToEdit.FirstName;
            userInDb.LastName = userToEdit.LastName;
            userInDb.Email = userToEdit.Email;
            userInDb.Password = userToEdit.Password;
            userInDb.TypeOfIdentificationId = userToEdit.TypeOfIdentificationId;
            userInDb.IdentificationNumber = userToEdit.IdentificationNumber;
            userInDb.IsActive = userToEdit.IsActive;

            _context.User.Update(userInDb);

            if(userToEdit.UsersHeadquarters == null)
            {
                return new User();
            }
            if(userToEdit.UsersHeadquarters != null)
            {
                var usersHqInDb = await _context.UsersHeadquarters.Where(uHq => uHq.UserId == userInDb.Id).ToListAsync();

                _context.UsersHeadquarters.RemoveRange(usersHqInDb);

                foreach (var hqId in userToEdit.UsersHeadquarters)
                {
                    var userHq = new UsersHeadquarters() 
                    {
                        UserId = userInDb.Id,
                        HeadquarterId = hqId.HeadquarterId
                    };

                    await _context.UsersHeadquarters.AddAsync(userHq);
                }
            }

            if(userToEdit.UsersRoles == null)
            {
                return new User();
            }
            if(userToEdit.UsersRoles != null)
            {
                var usersHqInDb = await _context.UsersRoles.Where(uHq => uHq.UserId == userInDb.Id).ToListAsync();

                _context.UsersRoles.RemoveRange(usersHqInDb);

                foreach (var roleId in userToEdit.UsersRoles)
                {
                    var userHq = new UsersRoles() 
                    {
                        UserId = userInDb.Id,
                        RolesId = roleId.RolesId
                    };

                    await _context.UsersRoles.AddAsync(userHq);
                }
            }

            await _context.SaveChangesAsync();

            return userInDb;
        }
        
        public async Task<User> Inactivate(int userId)
        {
            if(_context.User == null)
            {
                return new User();
            }

            var userInDb = await _context.User.FindAsync(userId);
            if(userInDb == null)
            {
                return new User();
            }

            userInDb.IsActive = false;


            _context.User.Update(userInDb);
            await _context.SaveChangesAsync();

            return userInDb;
        }
    }
}