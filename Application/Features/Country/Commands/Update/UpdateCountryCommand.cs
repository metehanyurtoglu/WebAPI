using Application.Common;
using MediatR;

namespace Application.Features.Country.Commands.Update
{
    public class UpdateCountryCommand : IRequest<Response<Domain.Entities.Country>>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
