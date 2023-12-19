using emz.Data;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  HeadquarterController : ControllerBase
    {
        private readonly IHeadquarterService _headquarterService;
        public HeadquarterController(IHeadquarterService headquarterService)
        {
            _headquarterService = headquarterService;
        }

        [HttpGet("GetAll")]
        public async Task<List<Headquarter>> GetAll()
        {
            return await _headquarterService.GetAll();
        }

        [HttpGet("Get")]
        public async Task<Headquarter> Get(int hqId)
        {
            return await _headquarterService.Get(hqId);
        }

        [HttpPost("Create")]
        public async Task<Headquarter> Create(Headquarter hqToCreate)
        {
            return await _headquarterService.Create(hqToCreate);
        }

        [HttpPut("Edit")]
        public async Task<Headquarter> Edit(Headquarter hqToEdit)
        {
            return await _headquarterService.Edit(hqToEdit);
        }

        [HttpPut("Inactivate")]
        public async Task<Headquarter> Inactivate(int hqId)
        {
            return await _headquarterService.Inactivate(hqId);
        }
    }
}