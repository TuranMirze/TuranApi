using Crud_Api.DTO.Games;
using Crud_Api.Entities;
namespace Crud_Api.Services.Abstracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesGetDto>> GetAllAsync();
        Task<Guid> CreateAsync(GamesCreateDto dto);
        Task StartAsync(Guid id);
        Task UpdateAsync(GamesUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
