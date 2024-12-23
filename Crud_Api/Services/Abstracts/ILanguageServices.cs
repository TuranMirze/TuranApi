using Crud_Api.DTO.Languages;

namespace Crud_Api.Services.Abstracts
{
    public interface ILanguageServices
    {
        Task CreateAsycn(LanguageCreateDto dto);
        Task <IEnumerable<LanguageGetDto>> GetAllAsycn();
        Task UpdateAsync(LanguageUpdateDto dto);
        Task DeleteAsycn(string dto);

    }
}
