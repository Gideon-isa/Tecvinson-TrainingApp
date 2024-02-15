using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Services.Contracts
{
    public class ApplicantCreateReqValidator : AbstractValidator<ApplicantCreateReq>
    {
        public ApplicantCreateReqValidator()
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

            RuleFor(m => m.Address)
               .NotEmpty()
               .WithMessage("Address name is required");

            RuleFor(m => m.EmploymentStatus)
               .NotEmpty()
               .WithMessage("Employment Status name is required");

            RuleFor(m => m.Gender)
               .NotEmpty()
               .WithMessage("Gender name is required");
        }
    }
}
