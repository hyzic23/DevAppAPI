using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dev.App.Api.DataAccess.Repo;
using Dev.App.Api.Dtos;
using Dev.App.Api.Interfaces;
using Dev.App.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.App.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            //throw new UnauthorizedAccessException();
            var cities = await unitOfWork.CityRepository.GetCitiesAsync();
            
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }


        [HttpPost]
        [Route("AddCity")]
        public async Task<IActionResult> AddCity(CityDto request)
        {
            var city = mapper.Map<City>(request);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = System.DateTime.Now;
            unitOfWork.CityRepository.AddCity(city);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            unitOfWork.CityRepository.DeleteCity(id);
            await unitOfWork.SaveAsync();
            return Ok(id);
        }





    }


    
}