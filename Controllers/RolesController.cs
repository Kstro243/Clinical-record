using emz.Data;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet("Get")]
        public async Task<List<Roles>> Get()
        {
            return await _rolesService.GetRoles();
        }
    }
}