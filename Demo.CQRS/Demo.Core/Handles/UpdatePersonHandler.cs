using Demo.Core.Commands;
using Demo.Core.DataAccess;
using Demo.Core.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Handles
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;

        public UpdatePersonHandler(IDataAccess data)
        {
            this._data = data;
        }
        public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.UpdatePerson(request.id, request.FirstName, request.LastName));
        }
    }
}
