using Demo.Core.Models;
using MediatR;

namespace Demo.Core.Commands
{
    public record UpdatePersonCommand(int id, string FirstName, string LastName) : IRequest<PersonModel>;
}
