using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.Delete
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Response<string>>
    {
        private readonly IRepository<Domain.Entities.City> _cityRepository;

        public DeleteCityCommandHandler(IRepository<Domain.Entities.City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response<string>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            if (city is null)
            {
                throw new Exception("City not exist!");
            }

            await _cityRepository.RemoveAsync(request.Id);

            return new Response<string>
            {
                 IsSuccess = true
            };
        }
    }
}
