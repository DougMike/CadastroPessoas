using CadastroPessoa.Domain.Entities;
using FluentValidation;

namespace CadastroPessoa.Application.Validators
{
    public class FileValidator : AbstractValidator<FileImport>
    {
        public FileValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(f => f.Size)
                .NotEmpty().WithMessage("Envie um arquivo com tamanho válido.");
        }
    }



}
