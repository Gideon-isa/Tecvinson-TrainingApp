using FluentValidation;
using TecvinsonBootcamp.Domain.Enums;

namespace TecvinsonBootcamp.Services.Contracts
{
    public class ApplicantUpdateReqValidator : AbstractValidator<ApplicantUpdateReq>
    {
        public ApplicantUpdateReqValidator()
        {
            RuleFor(m => m.FirstName)
               .NotEmpty()
               .WithMessage("First name is required");

            RuleFor(m => m.LastName)
               .NotEmpty()
               .WithMessage("Last name is required");

            RuleFor(m => m.Email)
               .NotEmpty()
               .WithMessage("Email address is required");

            RuleFor(m => m.Phone)
               .NotEmpty()
               .WithMessage("Phone number is required");

            RuleFor(m => m.EmploymentStatus)
               .NotEmpty()
               .WithMessage("Employment Status name is required and must be either any of these: " +
               "Worker, Employee, Self Employed or Unemployed");

            RuleFor(m => m.Gender)
               .NotEmpty()
               .WithMessage("Gender name is required");

            
        }

    }
}
