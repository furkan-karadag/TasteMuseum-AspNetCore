using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.ValidationRules
{
    public class UserValidator : GenericValidator<User>
    {
        public UserValidator()
        {

            EntityNullCheck();

            RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Must(HasNoNumbers).WithMessage("Name cannot contain numbers.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

        }
    }
}