using EatingApp.Core.DTO;
using FluentValidation;
using System;

namespace EatingApp.Core.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(User => User.FullName).NotNull().MaximumLength(40).Matches(@"\w+ \w+");
            RuleFor(User => User.BirthDate).LessThan(DateTime.UtcNow).GreaterThan(DateTime.MinValue);
        }
    }
}
