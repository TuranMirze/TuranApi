using AutoMapper;
using Crud_Api.DAL;
using Crud_Api.Entities;
using Crud_Api.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Crud_Api.DTO.Games;
using System;


namespace Crud_Api.Services.Implements
{
    public class GameService(TabuDbContext _sql, IMapper _mapper) : IGameService
    {
        public async Task CreateAsync(GamesCreateDto dto)
        {
            var context = _mapper.Map<Game>(dto);
            await _sql.Games.AddAsync(context);
            await _sql.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var context = await _sql.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (context != null)
            {
                _sql.Games.Remove(context);
            }
            _sql.SaveChangesAsync();
        }

        public async Task<IEnumerable<GamesGetDto>> GetAllAsync()
        {
            var context = await _sql.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GamesGetDto>>(context);
        }

        public async Task UpdateAsync(GamesUpdateDto dto)
        {
            var context = await _sql.Games.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (context != null)
            {
                _mapper.Map(dto, context);
            }
            await _sql.SaveChangesAsync();
        }

    }
}
