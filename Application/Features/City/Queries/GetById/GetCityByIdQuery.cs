using Application.Common;
using MediatR;

namespace Application.Features.City.Queries.GetById
{
    public class GetCityByIdQuery : IRequest<Response<Domain.Entities.City>>
    {
        public string Id { get; set; }
    }
}
