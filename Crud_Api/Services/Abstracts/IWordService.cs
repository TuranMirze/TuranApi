using Crud_Api.DTO.Words;
namespace Crud_Api.Services.Abstracts
{
    public interface IWordService
    {
        Task<IEnumerable<WordsGetDto>> GetAllAsync();
        Task CreateAsync(WordsCreateDto dto);
        Task UpdateAsync(WordsUpdateDto dto);
        Task DeleteAsync(string code);
    }
}
