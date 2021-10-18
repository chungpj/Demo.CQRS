using Demo.Core.Models;
using Demo.Core.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Handles
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var rs = await _mediator.Send(new GetPersonListQuery());
            var output = rs.FirstOrDefault(x => x.Id == request.Id);

            return output;
        }
    }
}
