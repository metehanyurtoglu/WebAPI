using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.City.Commands.Create
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Response<Domain.Entities.City>>
    {
        private readonly IRepository<Domain.Entities.City> _cityRepository;
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public CreateCityCommandHandler(IRepository<Domain.Entities.City> cityRepository, IRepository<Domain.Entities.Country> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task<Response<Domain.Entities.City>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.CountryId);

            await _cityRepository.CreateAsync(new Domain.Entities.City
            {
                Name = request.Name,
                Country = country
            });

            return new Response<Domain.Entities.City>
            {
                IsSuccess = true
            };
        }
    }
}
