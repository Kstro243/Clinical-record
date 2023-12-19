using emz.Data;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  LogController : ControllerBase
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost("Create")]
        public async Task<Log> Create(Log logToCreate)
        {
            return await _logService.Create(logToCreate);
        }
    }
}