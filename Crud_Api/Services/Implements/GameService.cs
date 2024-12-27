using AutoMapper;
using Crud_Api.DAL;
using Crud_Api.Entities;
using Crud_Api.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Crud_Api.DTO.Games;
using System;
using Microsoft.Extensions.Caching.Memory;


namespace Crud_Api.Services.Implements
{
    public class GameService(TabuDbContext _context, IMapper _mapper,IMemoryCache _cache) : IGameService
    {
     

        
        public async Task DeleteAsync(Guid id)
        {
            var context = await _context.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (context != null)
            {
                _context.Games.Remove(context);
            }
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GamesGetDto>> GetAllAsync()
        {
            var context = await _context.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GamesGetDto>>(context);
        }

        public async Task UpdateAsync(GamesUpdateDto dto)
        {
            var context = await _context.Games.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (context != null)
            {
                _mapper.Map(dto, context);
            }
            await _context.SaveChangesAsync();
        }

        async  Task<Guid> IGameService.CreateAsync(GamesCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

      
        Task IGameService.StartAsync(Guid id )
        {
            GameStatusDto dto = new GameStatusDto
            {
            
                UsedWordsIds = [],
                Skip = 0,
                Success = 0 ,
                Fail = 0 ,  
                Words = []
            };
            _cache.Set(id, dto,TimeSpan.FromMinutes(10));

          

            return Task.CompletedTask;

        }


        Task IGameService.UpdateAsync(GamesUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        Task IGameService.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        
    }
}
