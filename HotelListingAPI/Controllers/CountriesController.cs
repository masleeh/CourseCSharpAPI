using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
using HotelListingData;
using HotelListingCore.Models.Country;
using HotelListingCore.Contracts;
using HotelListingCore.Models;

namespace HotelListingAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync<GetCountryDTO>();
            return Ok(countries);
        }

        // GET: api/Countries?StartIndex=0&PageSize=20&PageIndex=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetCountryDTO>>> GetPagedCountries([FromQuery] QueryParameters queryParams)
        {
            var pagedCountries = await _countriesRepository.GetAllAsync<GetCountryDTO>(queryParams);
            return Ok(pagedCountries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDTO>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetCountryDetails(id);
            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO dto)
        {
            try
            {
                await _countriesRepository.UpdateAsync(id, dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _countriesRepository.DoesExist(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateCountryDTO>> PostCountry(CreateCountryDTO dto)
        {
            var country = await _countriesRepository.AddAsync<CreateCountryDTO, Country>(dto);
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _countriesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
