using Crud_Api.DTO.Games;
using FluentValidation;

namespace Crud_Api.Validators.Games
{
    public class GamesCreateValidator : AbstractValidator<GamesCreateDto>
    {
        public GamesCreateValidator()
        {
            
        }
    }
}
