using AutoMapper;
using Crud_Api.DAL;
using Crud_Api.DTO.Words;
using Crud_Api.Entities;
using Crud_Api.Services.Abstracts;
using System;
using Microsoft.EntityFrameworkCore;

namespace Crud_Api.Services.Implements
{
    public class WordService(TabuDbContext _context, IMapper _mapper) : IWordService
    {
        public async Task<IEnumerable<WordsGetDto>> GetAllAsync()
        {
            var context = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordsGetDto>>(context);
        }


        public async Task CreateAsync(WordsCreateDto dto)
        {
            var context = _mapper.Map<Word>(dto);
            await _context.Words.AddAsync(context);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteAsync(string code)
        {
            var context = await _context.Languages.Where(x => x.Code==code).FirstOrDefaultAsync();
            if (context != null)
            {
                _context.Languages.Remove(context);
            }
            await _context.SaveChangesAsync();
        }



        public async Task UpdateAsync(WordsUpdateDto dto)
        {
            var context = _context.Words.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (context != null)
            {
                _mapper.Map(dto, context);
            }
            await _context.SaveChangesAsync();
        }
    }
}

