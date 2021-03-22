using Business.IO.Produto;
using Business.IO.Users;
using FluentValidation;
using System;

namespace Business.Validations
{
    public class ProdutoValidation : AbstractValidator<ProdutoInput>
    {
        public ProdutoValidation()
        {
            RuleFor(f => f.Nome)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Imagem)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }    
    }
}