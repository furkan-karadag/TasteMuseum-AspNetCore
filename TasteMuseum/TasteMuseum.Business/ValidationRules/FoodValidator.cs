using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.ValidationRules
{
    public class FoodValidator:GenericValidator<Food>
    {
        public FoodValidator()
        {
            
            EntityNullCheck();

            
            RuleFor(food => food.Name)
                .NotEmpty().WithMessage("Food name is required.")
                .Must(HasNoNumbers).WithMessage("Food name cannot contain numbers.");

            RuleFor(food => food.Ingredients)
                .NotEmpty().WithMessage("Ingredients are required.")
                .Length(5, 500).WithMessage("Ingredients length must be between 5 and 500 characters.");

            RuleFor(food => food.Recipe)
                .NotEmpty().WithMessage("Recipe is required.")
                .Length(10, 2000).WithMessage("Recipe length must be between 10 and 2000 characters.");
        }
    }
}
