using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Country.Commands.Create
{
    public class CreateCountryCommand : IRequest<Response<Domain.Entities.Country>>
    {
        public string Name { get; set; }
    }
}
