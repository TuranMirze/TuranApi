using AutoMapper;
using Crud_Api.DTO.Games;
using Crud_Api.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var context = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GamesCreateDto>>(context);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GamesCreateDto dto)
        {
            var context = _mapper.Map<GamesCreateDto>(dto);
            await _service.CreateAsync(context);
            return Ok(context);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GamesUpdateDto dto)
        {
            var context = _mapper.Map<GamesUpdateDto>(dto);
            await _service.UpdateAsync(context);
            return Ok(context);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
