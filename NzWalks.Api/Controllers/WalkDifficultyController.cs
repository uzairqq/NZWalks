using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Dto;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(AddUpdateWalkDifficultyDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(dto);
                }
                var walkDifficulty = await _walkDifficultyRepository.AddAsync(dto);
                return Ok(walkDifficulty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        [HttpPut]
        [Route("id:{guid}")]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] AddUpdateWalkDifficultyDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(dto);
                }
                var walkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, dto);
                return Ok(walkDifficulty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var walkDifficulty = await _walkDifficultyRepository.GetAllAsync();
                if (walkDifficulty == null)
                {
                    return NotFound();
                }
                return Ok(walkDifficulty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("id:{guid}")]
        public async Task<IActionResult> GetAllAsync(Guid id)
        {
            try
            {
                var walkDifficulty = await _walkDifficultyRepository.GetByIdAsync(id);
                if (walkDifficulty == null)
                {
                    return NotFound();
                }
                return Ok(walkDifficulty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        [HttpDelete]
        [Route("id:{guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var walkDifficulty = await _walkDifficultyRepository.GetByIdAsync(id);
                if (walkDifficulty == null)
                {
                    return NotFound();
                }
                return Ok(walkDifficulty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
