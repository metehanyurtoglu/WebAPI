using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Country.Commands.Delete
{
    public class DeleteCountryCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
