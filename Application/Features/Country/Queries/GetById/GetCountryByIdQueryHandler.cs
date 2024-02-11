using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Queries.GetById
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Response<Domain.Entities.Country>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public GetCountryByIdQueryHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Response<Domain.Entities.Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _countryRepository.GetAsync(request.Id);

            return new Response<Domain.Entities.Country>
            {
                IsSuccess = true,
                Data = result
            };
        }
    }
}
