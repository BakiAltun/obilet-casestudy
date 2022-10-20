using FluentValidation;
using OBilet.CaseStudy.ApplicationCore.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Validations
{
    public class GetJourneyQueryValidator : AbstractValidator<GetJourneyQuery>
    {
        public GetJourneyQueryValidator()
        {
            RuleFor(query => query.OriginId).NotEqual(query => query.DestinationId).WithMessage("Başlagıç ve Bitiş lokasyonu aynı olamaz");
            RuleFor(query => query.DepartureDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("En erken tarih bugün olabilir");
        }
    }
}
