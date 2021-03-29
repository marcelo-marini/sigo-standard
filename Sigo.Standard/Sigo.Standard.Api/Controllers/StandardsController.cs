using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigo.Standard.Api.Application;
using Sigo.Standard.Api.Models.Request;

namespace Sigo.Standard.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StandardsController : ControllerBase
    {
        private readonly IStandardAppService _appService;
        
        public StandardsController(IStandardAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStandardRequest request)
        {
            var response = await _appService.Create(request);
            return Ok(response);
        }
    }
}