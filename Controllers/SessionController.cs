using emz.Data;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost("Create")]
        public async Task<Session> Create(Session sessionToCreate)
        {
            return await _sessionService.Create(sessionToCreate);
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(int sessionId)
        {
            return await _sessionService.Delete(sessionId);
        }
    }
}