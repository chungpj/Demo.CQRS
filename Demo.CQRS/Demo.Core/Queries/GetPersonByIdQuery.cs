using Demo.Core.Models;
using MediatR;

namespace Demo.Core.Queries
{
    public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;
}
