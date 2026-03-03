using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Country.API.DTOs.CityDto;
using Country.API.Models.City;
using Country.API.Repository.Interfaces;

namespace Country.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IGenericRepository<CityModel> _repository;
        private readonly IMapper _mapper;

        public CityController(
            IGenericRepository<CityModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/City
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CityResponseDto>>(cities);

            return Ok(result);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _repository.GetByIdAsync(id);

            if (city == null)
                return NotFound("City not found");

            var result = _mapper.Map<CityResponseDto>(city);

            return Ok(result);
        }

        // GET: api/City/by-state/1
        [HttpGet("by-state/{stateId}")]
        public async Task<IActionResult> GetByState(int stateId)
        {
            var cities = await _repository.FindAsync(c => c.StateId == stateId);
            var result = _mapper.Map<IEnumerable<CityResponseDto>>(cities);

            return Ok(result);
        }

        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = _mapper.Map<CityModel>(dto);

            await _repository.AddAsync(city);
            await _repository.SaveChangesAsync();

            var response = _mapper.Map<CityResponseDto>(city);

            return CreatedAtAction(nameof(GetById), new { id = city.Id }, response);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCity = await _repository.GetByIdAsync(id);

            if (existingCity == null)
                return NotFound("City not found");

            _mapper.Map(dto, existingCity);

            _repository.Update(existingCity);
            await _repository.SaveChangesAsync();

            return Ok("City updated successfully");
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _repository.GetByIdAsync(id);

            if (city == null)
                return NotFound("City not found");

            _repository.Delete(city);
            await _repository.SaveChangesAsync();

            return Ok("City deleted successfully");
        }
    }
}