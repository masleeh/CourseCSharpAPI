using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingCore.Repositories;
using AutoMapper;
using HotelListingData;
using HotelListingCore.Contracts;
using HotelListingCore.Models.Hotel;

namespace HotelListingAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _hotelRepository;

        public HotelsController(IMapper mapper, IHotelsRepository hotelRepository)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelDTO>>>GetHotels()
        {
            IEnumerable<Hotel> hotels = await _hotelRepository.GetAllAsync();
            var records = _mapper.Map<IEnumerable<GetHotelDTO>>(hotels);
            return Ok(records);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
                return NotFound();

            var hotelDto = _mapper.Map<GetHotelDTO>(hotel);
            return Ok(hotelDto);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, CreateHotelDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();
            Hotel hotel = await _hotelRepository.GetAsync(dto.Id);
            _mapper.Map(dto, hotel);
            try
            {
                await _hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _hotelRepository.DoesExist(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDTO dto)
        {
            Hotel hotel = _mapper.Map<Hotel>(dto);
            await _hotelRepository.AddAsync(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
                return NotFound();
            await _hotelRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
