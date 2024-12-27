//using AutoMapper;
using AutoMapper;
using Crud_Api.DTO.Games;
using Crud_Api.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service, IMapper _mapper, IMemoryCache _cache) : ControllerBase
    {
        

       

        [HttpPost]
        public async Task<IActionResult> Create(GamesCreateDto dto)
        {
            //var context = _mapper.Map<GamesCreateDto>(dto);
          
           
            return Ok(await _service.CreateAsync(dto));
            //return Ok(await _service.CreateAsync(dto));
        }
        [HttpGet]
        public async Task<IActionResult> Start(Guid id)
        {
            return Ok();
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
