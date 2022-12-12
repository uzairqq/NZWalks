using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Dto;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;

        public WalkController(IWalkRepository walkRepository)
        {
            _walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostWalkAsync(AddUpdateWalksDto addUpdateWalksDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var walk = await _walkRepository.PostWalksAsync(addUpdateWalksDto);
                if (walk == null)
                {
                    return NotFound();
                }
                return Ok(walk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutWalkAsync([FromRoute] Guid id, [FromBody] AddUpdateWalksDto addUpdateWalksDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var walk = await _walkRepository.UpdateWalksAsync(id, addUpdateWalksDto);
                if (walk == null)
                {
                    return NotFound();
                }
                return Ok(walk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            try
            {
                var walk = await _walkRepository.GetWalkAsync(id);
                if (walk == null)
                {
                    return NotFound();
                }
                return Ok(walk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            try
            {
                var walk = await _walkRepository.GetAllWalksAsync();
                if (walk == null)
                {
                    return NotFound();
                }
                return Ok(walk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalksAsync(Guid id)
        {
            try
            {
                var walk = await _walkRepository.DeleteWalksAsync(id);
                if (walk == null)
                {
                    return NotFound();
                }
                return Ok(walk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


    }
}
