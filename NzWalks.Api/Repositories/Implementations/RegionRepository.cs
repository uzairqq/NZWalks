﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext _nzWalksDbContext;
        private readonly IMapper _mapper;

        public RegionRepository(NzWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            _nzWalksDbContext = nzWalksDbContext;
            _mapper = mapper;
        }

       

        public async Task<IEnumerable<RegionsDto>> GetAllAsync()
        {
            try
            {
                var regions = await _nzWalksDbContext.Regions.ToListAsync();
                var regionsDto = _mapper.Map<IEnumerable<RegionsDto>>(regions);
                return regionsDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegionsDto> GetRegionAsync(Guid id)
        {
            try
            {
                var region = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(i => i.Id == id);
                var regionDto = _mapper.Map<RegionsDto>(region);
                return regionDto;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<RegionsDto> PostRegionAsync(AddRegionDto dto)
        {
            try
            {
                var region = await _nzWalksDbContext.Regions.AddAsync(new Region()
                {
                    Lat = dto.Lat,
                    Long = dto.Long,
                    Area = dto.Area,
                    Code = dto.Code,
                    Name = dto.Name,
                    Population = dto.Population,
                });
                await _nzWalksDbContext.SaveChangesAsync();

                var regionsMapping = new RegionsDto()
                {
                    Id = region.Entity.Id,
                    Area=region.Entity.Area,
                    Code=region.Entity.Code,
                    Lat=region.Entity.Lat,
                    Long=region.Entity.Long,
                    Name=region.Entity.Name,
                    Population=region.Entity.Population
                };
                return regionsMapping;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegionsDto> DeleteRegionAsync(Guid id)
        {
            try
            {
                var region =await _nzWalksDbContext.Regions.FirstOrDefaultAsync(i => i.Id == id);
                if (region == null)
                {
                    return new RegionsDto();
                }
                _nzWalksDbContext.Regions.Remove(region);
                await _nzWalksDbContext.SaveChangesAsync();

                var regionsDtoMapping=new RegionsDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Population = region.Population,
                    Area = region.Area,
                    Code = region.Code,
                    Lat = region.Lat,
                    Long = region.Long
                };

                return regionsDtoMapping;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
