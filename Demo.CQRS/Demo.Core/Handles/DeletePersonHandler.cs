using Demo.Core.Commands;
using Demo.Core.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Handles
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IDataAccess _data;

        public DeletePersonHandler(IDataAccess data)
        {
            this._data = data;
        }
        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.DeletePerson(request.id));
        }
    }
}
