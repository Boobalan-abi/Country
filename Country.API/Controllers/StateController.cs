using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Country.API.DTOs.StateDto;
using Country.API.Models.State;
using Country.API.Repository.Interfaces;

namespace Country.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IGenericRepository<StateModel> _repository;
        private readonly IMapper _mapper;

        public StateController(
            IGenericRepository<StateModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/State
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var states = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<StateResponseDto>>(states);

            return Ok(result);
        }

        // GET: api/State/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var state = await _repository.GetByIdAsync(id);

            if (state == null)
                return NotFound("State not found");

            var result = _mapper.Map<StateResponseDto>(state);

            return Ok(result);
        }

        // GET: api/State/by-country/1
        [HttpGet("by-country/{countryId}")]
        public async Task<IActionResult> GetByCountry(int countryId)
        {
            var states = await _repository.FindAsync(s => s.CountryId == countryId);

            var result = _mapper.Map<IEnumerable<StateResponseDto>>(states);

            return Ok(result);
        }

        // POST: api/State
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var state = _mapper.Map<StateModel>(dto);

            await _repository.AddAsync(state);
            await _repository.SaveChangesAsync();

            var response = _mapper.Map<StateResponseDto>(state);

            return CreatedAtAction(nameof(GetById), new { id = state.Id }, response);
        }

        // PUT: api/State/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingState = await _repository.GetByIdAsync(id);

            if (existingState == null)
                return NotFound("State not found");

            _mapper.Map(dto, existingState);

            _repository.Update(existingState);
            await _repository.SaveChangesAsync();

            return Ok("State updated successfully");
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var state = await _repository.GetByIdAsync(id);

            if (state == null)
                return NotFound("State not found");

            _repository.Delete(state);
            await _repository.SaveChangesAsync();

            return Ok("State deleted successfully");
        }
    }
}