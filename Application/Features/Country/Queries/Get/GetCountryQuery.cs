using Application.Common;
using MediatR;

namespace Application.Features.Country.Queries.Get
{
    public class GetCountryQuery : IRequest<Response<List<Domain.Entities.Country>>>
    {
    }
}
