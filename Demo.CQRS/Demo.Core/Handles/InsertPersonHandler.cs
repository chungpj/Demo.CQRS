using Demo.Core.Commands;
using Demo.Core.DataAccess;
using Demo.Core.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Handles
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;

        public InsertPersonHandler(IDataAccess data)
        {
            this._data = data;
        }
        public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
        }
    }
}
