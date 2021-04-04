using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigo.Standard.Api.Application;
using Sigo.Standard.Api.Models.Request;

namespace Sigo.Standard.Api.Controllers
{
    [Authorize("ClientIdPolicy")]
    [Route("api/[controller]")]
    public class StandardsController : ControllerBase
    {
        private readonly IStandardAppService _appService;

        public StandardsController(IStandardAppService appService)
        {
            _appService = appService;
        }

        [Route(""), HttpGet]
        public async Task<IActionResult> GetStandardsAsync()
        {
            var response = await _appService.GetAllAsync();

            if (!response.Any())
            {
                return NoContent();
            }

            return Ok(response);
        }

        [Route("{id}"), HttpGet]
        public async Task<IActionResult> GetStandardByExternalIdAsync([FromRoute] string id)
        {
            var response = await _appService.GetbyExternalIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStandardRequest request)
        {
            var response = await _appService.CreateAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStandarRequest request)
        {
            var response = await _appService.UpdateAsync(request);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [Route("{id}"), HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _appService.DeleteAsync(id);
            return Ok();
        }
    }
}