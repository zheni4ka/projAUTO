using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;

namespace BusinessLogic.Validators
{
    public class AutoValidator : AbstractValidator<AutoDto>
    {
        public AutoValidator() 
        { 
            RuleFor(x => x.Mark)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.Model)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.YearRelease)
                .NotEmpty()
                .GreaterThan(1488)
                .LessThan(2077);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cant be less than 0.");

            RuleFor(x => x.Speed)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cant pe less than 0");

            RuleFor(x => x.Description)
                .Length(10, 4000)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.ImgURL)
                .NotEmpty()
                .Must(LinkMustBeAUri).WithMessage("{PropertyName} must be a valid URL address.");
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
