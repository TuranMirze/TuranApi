using Crud_Api.DTO.Languages;
using FluentValidation;

namespace Crud_Api.Validators.Languages
{
    public class LanguageCreateDtoValidator: AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Ad bos ola bilmez")
                .NotNull()
                .WithMessage("Ad null ola bilmez")
                .Length(2)
                .WithMessage("Ad uzunlugu 2 den boyuk ola bilmez");

            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3);

            RuleFor(x => x.IconUrl)
                .MaximumLength(128)
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$\r\n")
                .WithMessage("Url Link Olmalidir");


        }
    }
}
