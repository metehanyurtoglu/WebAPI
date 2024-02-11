using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.Create
{
    public class CreateCityCommand : IRequest<Response<Domain.Entities.City>>
    {
        public string Name { get; set; }
        public string CountryId { get; set; }
    }
}
