using Crud_Api.DTO.BannedWord;

namespace Crud_Api.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task<BannedWordGetDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, BannedWordUpdateDto dto);
    }
}
