using CadastroPessoa_API.Models;
using FluentValidation;

namespace CadastroPessoa_API.Services.Validator
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Insira um nome!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Sobrenome)
                .NotEmpty().WithMessage("Insira um sobrenome!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Nacionalidade)
                .NotEmpty().WithMessage("Insira uma nacionalidade!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.CEP)
                .NotEmpty().WithMessage("Insira um CEP!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("Insira um estado!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Cidade)
                .NotEmpty().WithMessage("Insira uma cidade!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Logradouro)
                .NotEmpty().WithMessage("Insira um logradouro!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Insira um e-mail!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
            
            RuleFor(p => p.Telefone)
                .NotEmpty().WithMessage("Insira um telefone!")
                .NotNull().WithMessage("Campo não pode ser vazio.");
        }
    }
}
