using Crud_Api.DTO.Games;
namespace Crud_Api.Services.Abstracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesGetDto>> GetAllAsync();
        Task CreateAsync(GamesCreateDto dto);
        Task UpdateAsync(GamesUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
