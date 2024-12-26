using AutoMapper;
using Crud_Api.DTO.Words;
using Crud_Api.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var context = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<WordsGetDto>>(context);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(WordsCreateDto dto)
        {
            var context = _mapper.Map<WordsCreateDto>(dto);
            await _service.CreateAsync(context);
            return Ok(context);
        }

        [HttpPut]
        public async Task<IActionResult> Update(WordsUpdateDto dto)
        {
            var context = _mapper.Map<WordsUpdateDto>(dto);
            await _service.UpdateAsync(context);
            return Ok(context);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }


    }
}
