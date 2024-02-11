using Application.Common;
using MediatR;

namespace Application.Features.City.Queries.Get
{
    public class GetCityQuery : IRequest<Response<List<Domain.Entities.City>>>
    {
    }
}
