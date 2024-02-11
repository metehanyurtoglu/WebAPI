using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Commands.Create
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Response<Domain.Entities.Country>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public CreateCountryCommandHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        async Task<Response<Domain.Entities.Country>> IRequestHandler<CreateCountryCommand, Response<Domain.Entities.Country>>.Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryRepository.CreateAsync(new Domain.Entities.Country
            {
                Name = request.Name
            });

            return new Response<Domain.Entities.Country>
            {
                IsSuccess = true
            };
        }
    }
}
