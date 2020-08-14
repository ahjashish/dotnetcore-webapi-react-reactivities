using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ahj.ashish.reactivities.Application.Activities;
using ahj.ashish.reactivities.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ahj.ashish.reactivities.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ActivitiesController
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> ListAsync()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> DetailsAsync(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAsync(Create.Command command)
        {
            return await _mediator.Send(new Create.Command());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditAsync(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(new Edit.Command());
        }
    }
}