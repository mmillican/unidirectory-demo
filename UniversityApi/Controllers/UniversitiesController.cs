using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UniversityApi.Config;
using UniversityApi.Models;
using UniversityApi.Services;

namespace UniversityApi.Controllers
{
    [Route("universities")]
    public class UniversitiesController : Controller
    {
        private readonly IUniversityService _universityService;
        private readonly ILogger<UniversitiesController> _logger;
        private readonly UniversityConfig _config;

        public UniversitiesController(IUniversityService universityService,
            ILogger<UniversitiesController> logger,
            IOptions<UniversityConfig> config)
        {
            _universityService = universityService;
            _logger = logger;
            _config = config.Value;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTask(string name)
        {
            try 
            {
                name = WebUtility.UrlEncode(name);
                var country = WebUtility.UrlEncode(_config.SearchCountry);

                IEnumerable<UniversityModel> universities = await _universityService.SearchAsync(country, name);
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