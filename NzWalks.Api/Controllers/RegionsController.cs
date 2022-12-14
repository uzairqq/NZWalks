using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Dto;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                var regions = await _regionRepository.GetAllAsync();
                return Ok(regions);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            try
            {
                var region = await _regionRepository.GetRegionAsync(id);
                if (region == null)
                {
                    return NotFound();
                }
                return Ok(region);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRegionAsync(AddUpdateRegionDto dto)
        {
            try
            {
                var region = await _regionRepository.PostRegionAsync(dto);
                return CreatedAtAction("PostRegion", region);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            try
            {
                var region = await _regionRepository.DeleteRegionAsync(id);
                if (region == null)
                {
                    return NotFound();
                }
                return Ok(region);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionsAsync([FromRoute] Guid id, [FromBody] AddUpdateRegionDto addUpdateRegionDto)
        {
            try
            {
                var region = await _regionRepository.UpdateRegionsAsync(id, addUpdateRegionDto);
                if (region==null)
                {
                    return NotFound();
                }
                return Ok(region);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
