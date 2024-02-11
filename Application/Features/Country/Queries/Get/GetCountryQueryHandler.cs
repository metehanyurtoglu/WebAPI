using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Queries.Get
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, Response<List<Domain.Entities.Country>>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public GetCountryQueryHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Response<List<Domain.Entities.Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var result = await _countryRepository.GetAllAsync();

            return new Response<List<Domain.Entities.Country>>
            {
                IsSuccess = true,
                Data = (List<Domain.Entities.Country>)result
            };
        }
    }
}
