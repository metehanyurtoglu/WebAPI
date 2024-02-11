using Application.Common;
using MediatR;

namespace Application.Features.Country.Queries.GetById
{
    public class GetCountryByIdQuery : IRequest<Response<Domain.Entities.Country>>
    {
        public string Id { get; set; }
    }
}
