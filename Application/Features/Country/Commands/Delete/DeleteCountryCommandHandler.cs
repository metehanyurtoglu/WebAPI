using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Country.Commands.Delete
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Response<string>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public DeleteCountryCommandHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Response<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            if (country is null)
            {
                throw new Exception("Country not exist!");
            }

            await _countryRepository.RemoveAsync(request.Id);

            return new Response<string>
            {
                IsSuccess = true
            };
        }
    }
}
