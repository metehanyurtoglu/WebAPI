using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.Update
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Response<Domain.Entities.City>>
    {
        private readonly IRepository<Domain.Entities.City> _cityRepository;

        public UpdateCityCommandHandler(IRepository<Domain.Entities.City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response<Domain.Entities.City>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            if (city is null)
            {
                throw new Exception("City not exist!");
            }

            city.Name = request.Name;

            await _cityRepository.UpdateAsync(city);

            return new Response<Domain.Entities.City>
            {
                IsSuccess = true
            };
        }
    }
}
