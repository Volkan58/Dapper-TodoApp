using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Dto;
using TestApp.Application.Features.Commands;
using TestApp.Domain.Entiti;

namespace TestApp.Application.Validator
{
 public   class TodoValidator:AbstractValidator<InsertTodoCommands>
    {

        public TodoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş Geçme Test!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş Geçme Test!");
        }
    }
}
