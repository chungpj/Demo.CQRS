using MediatR;

namespace Demo.Core.Commands
{
    public record DeletePersonCommand(int id) : IRequest<bool>;
}
