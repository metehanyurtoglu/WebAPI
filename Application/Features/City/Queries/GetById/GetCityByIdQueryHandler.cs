using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.City.Queries.GetById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, Response<Domain.Entities.City>>
    {
        private readonly IRepository<Domain.Entities.City> _cityRepository;

        public GetCityByIdQueryHandler(IRepository<Domain.Entities.City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response<Domain.Entities.City>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cityRepository.GetAsync(request.Id);

            return new Response<Domain.Entities.City>
            {
                IsSuccess = true,
                Data = result
            };
        }
    }
}
