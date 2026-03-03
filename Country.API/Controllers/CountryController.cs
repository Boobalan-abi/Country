using AutoMapper;
using Country.API.DTOs.CountryDto;
using Country.API.Models.Country;
using Country.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Country.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IGenericRepository<CountryModel> _repository;
        private readonly IMapper _mapper;

        public CountryController(
            IGenericRepository<CountryModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Country/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _repository.GetAllAsync();

            var result = _mapper.Map<List<CountryResponseDto>>(countries);

            return Ok(result);
        }

        // GET: api/Country/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
                return NotFound("Country not found");

            var result = _mapper.Map<CountryResponseDto>(country);

            return Ok(result);
        }

        // POST: api/Country/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = _mapper.Map<CountryModel>(dto);

            await _repository.AddAsync(country);

            await _repository.SaveChangesAsync();

            var response = _mapper.Map<CountryResponseDto>(country);

            return CreatedAtAction(nameof(GetById), new { id = country.Id }, response);
        }

        // PUT: api/Country/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCountry = await _repository.GetByIdAsync(id);

            if (existingCountry == null)
                return NotFound("Country not found");

            _mapper.Map(dto, existingCountry);

            _repository.Update(existingCountry);

            await _repository.SaveChangesAsync();

            return Ok("Country updated successfully");
        }

        // DELETE: api/Country/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
                return NotFound("Country not found");

            _repository.Delete(country);

            await _repository.SaveChangesAsync();

            return Ok("Country deleted successfully");
        }
    }
}