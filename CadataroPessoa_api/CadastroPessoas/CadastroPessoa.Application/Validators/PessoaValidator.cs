using CadastroPessoa.Domain.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Application.Validators
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Nacionalidade)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.CEP)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Uf)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Localidade)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Logradouro)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Email)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");

            RuleFor(p => p.Telefone)
                            .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("Por favor, preencha o campo.");


        }
    }
}
