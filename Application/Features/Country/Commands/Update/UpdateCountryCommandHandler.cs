using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Country.Commands.Update
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Response<Domain.Entities.Country>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public UpdateCountryCommandHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Response<Domain.Entities.Country>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            if(country is null)
            {
                throw new Exception("Country not exist!");
            }

            country.Name = request.Name;

            await _countryRepository.UpdateAsync(country);

            return new Response<Domain.Entities.Country>
            {
                IsSuccess = true
            };
        }
    }
}
