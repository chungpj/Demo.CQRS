using Demo.Core.Commands;
using Demo.Core.Models;
using Demo.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<PersonModel> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel value)
        {
            var model = new InsertPersonCommand(value.FirstName, value.LastName);
            return await _mediator.Send(model);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonModel value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            var model = await _mediator.Send(new GetPersonByIdQuery(id));
            if (model == null)
            {
                return NotFound();
            }

            try
            {
                await _mediator.Send(new UpdatePersonCommand(id, value.FirstName, value.LastName));
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _mediator.Send(new GetPersonByIdQuery(id));
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                await _mediator.Send(new DeletePersonCommand(id));
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
