using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Tabs.Commands.AddTab;
using Tabloid.Application.CQRS.Tabs.Commands.DeleteTab;
using Tabloid.Application.CQRS.Tabs.Commands.UpdateTab;
using Tabloid.Application.CQRS.Tabs.Queries.FindTabById;
using Tabloid.Application.CQRS.Tabs.Queries.GetAllTabs;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/tabs")]
    public class TabController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TabController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTab([FromBody] TabDto tab)
        {
            var response = await _mediator.Send(new AddTabCommand(tab));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTab([FromBody] TabDto tab)
        {
            var response = await _mediator.Send(new UpdateTabCommand(tab));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTab([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteTabCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTabs()
        {
            var response = await _mediator.Send(new GetAllTabsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTabById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new FindTabByIdQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
