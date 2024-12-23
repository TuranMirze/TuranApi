using AutoMapper;
using Crud_Api.DTO.Languages;
using Crud_Api.Entities;
using Crud_Api.Exceptions;
using Crud_Api.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageServices _services) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return Ok(await _services.GetAllAsycn());
        }


        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                await _services.CreateAsycn(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Errormessage = bEx.ErrorMessage
                    });
                }
                else 
                {
                    return BadRequest(new
                    {
                        ex.Message
                    });
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            await _services.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _services.DeleteAsycn(code);
            return Ok();

        }
    }
}
