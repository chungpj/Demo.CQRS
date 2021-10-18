using Demo.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Demo.Core.Queries
{
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;
}
