using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.City.Queries.Get
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, Response<List<Domain.Entities.City>>>
    {
        private readonly IRepository<Domain.Entities.City> _cityRepository;

        public GetCityQueryHandler(IRepository<Domain.Entities.City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response<List<Domain.Entities.City>>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var result = await _cityRepository.GetAllAsync();

            return new Response<List<Domain.Entities.City>>
            {
                IsSuccess = true,
                Data = (List<Domain.Entities.City>) result
            };
        }
    }
}
