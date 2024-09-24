using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.ValidationRules
{
    public class RestaurantValidator:GenericValidator<Restaurant>
    {
        public RestaurantValidator()
        {
           
            EntityNullCheck();

           
            RuleFor(restaurant => restaurant.Name)
                .NotEmpty().WithMessage("Restaurant name is required.")
                .Must(HasNoNumbers).WithMessage("Restaurant name cannot contain numbers.");

            RuleFor(restaurant => restaurant.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 200).WithMessage("Address length must be between 5 and 200 characters.");

            RuleFor(restaurant => restaurant.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            
        }
    }
}
