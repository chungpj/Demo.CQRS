using Demo.Core.Models;
using MediatR;

namespace Demo.Core.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;
}
