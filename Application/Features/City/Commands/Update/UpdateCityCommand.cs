using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.Update
{
    public class UpdateCityCommand : IRequest<Response<Domain.Entities.City>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
