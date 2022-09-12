using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Application.Features.Commands;
using TestApp.Application.Features.Queries.GetAllTodos;
using TestApp.Application.Features.Queries.GetTodoById;
//using TestApp.Application.Features.Queries.GetTodoById;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTodoQuery();
            return Ok(await mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Post(InsertTodoCommands command)
        {

            return Ok(await mediator.Send(command));
        }

        [HttpGet("{İd}")]
        public async Task<IActionResult> GetId(int id)
        {
            if (id <= 0)
                return BadRequest();
            var query = new GetByTodoIdQuery() { ID = id };
            return Ok(await mediator.Send(query));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoCommands command)
        {
            if (command.ID <= 0)
                return BadRequest();

            
            return Ok(await mediator.Send(command));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var query = new RemoveTodoCommands() { ID = id };
            return Ok(await mediator.Send(query));


        }


    }
}
