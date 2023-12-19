using emz.Data;
using emz.Responses;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpGet("Get")]
        public async Task<User> Get(int userId)
        {
            return await _userService.Get(userId);
        }

        [HttpPost("Create")]
        public async Task<UserResponse> Create(User userToCreate)
        {
            return await _userService.Create(userToCreate);
        }

        [HttpPut("Edit")]
        public async Task<User> Edit(User userToEdit)
        {
            return await _userService.Edit(userToEdit);
        }

        [HttpPut("Inactivate")]
        public async Task<User> Inactivate(int userId)
        {
            return await _userService.Inactivate(userId);
        }
    }
}