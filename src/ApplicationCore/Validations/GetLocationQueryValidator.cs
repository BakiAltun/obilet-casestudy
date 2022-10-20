using FluentValidation;
using OBilet.CaseStudy.ApplicationCore.Queries;

namespace OBilet.CaseStudy.ApplicationCore.Validations
{
    public class GetLocationQueryValidator : AbstractValidator<GetLocationQuery>
    {
        public GetLocationQueryValidator()
        {

        }
    }
}
