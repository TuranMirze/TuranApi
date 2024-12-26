using AutoMapper;
using Crud_Api.DAL;
using Crud_Api.DTO.Languages;
using Crud_Api.Entities;
using Crud_Api.Exceptions;
using Crud_Api.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Crud_Api.Services.Implements
{
    public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageServices
    {
        public async Task CreateAsycn(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
            {
                throw new LanguageExistException();
            }
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsycn()
        {
            var context = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(context);
        }

        public async Task UpdateAsync(LanguageUpdateDto dto)
        {
            var _dto = await _context.Languages.Where(x => x.Code == dto.Code).FirstOrDefaultAsync();
            if (_dto != null)
            {
                _dto.Name = dto.Name;
                _dto.Code = dto.Code;
                _dto.Icon = dto.Icon;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var context = await _context.Languages.Where(x => x.Code == code).FirstOrDefaultAsync();
            if (context != null)
            {
                _context.Languages.Remove(context);
            }
            await _context.SaveChangesAsync();

        }

        public Task DeleteAsycn(string dto)
        {
            throw new NotImplementedException();
        }
    }
}
