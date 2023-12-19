using emz.Data;
using emz.Services;
using Microsoft.AspNetCore.Mvc;

namespace emz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeOfIdentificationController : ControllerBase
    {
        private readonly ITypeOfIdentificationService _typeOfIdentificationService;
        public TypeOfIdentificationController(ITypeOfIdentificationService typeOfIdentificationService)
        {
            _typeOfIdentificationService = typeOfIdentificationService;
        }

        [HttpGet("GetAll")]
        public async Task<List<TypeOfIdentification>> GetAll()
        {
            return await _typeOfIdentificationService.GetAll();
        }
    }
}