using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityApi.Services;

namespace UniversityApi.Controllers
{
    [Route("universities")]
    public class UniversitiesController : Controller
    {
        private readonly IUniversityService _universityService;
        private readonly ILogger<UniversitiesController> _logger;

        public UniversitiesController(IUniversityService universityService,
            ILogger<UniversitiesController> logger)
        {
            _universityService = universityService;
            this._logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTask(string name)
        {
            try 
            {
                var universities = await _universityService.SearchAsync(name);
                universities = universities.OrderBy(x => x.Name);

                return Ok(universities);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving universities");
                
                return StatusCode(500, ex.Message);
            }
        }
    }
}