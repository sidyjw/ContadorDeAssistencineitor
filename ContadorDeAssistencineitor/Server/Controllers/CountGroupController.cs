using ContadorDeAssistencineitor.Application.DTOs;
using ContadorDeAssistencineitor.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CountGroup.Commands;
using Application.CountGroup.Queries;
using CountGroupDTO = ContadorDeAssistencineitor.Application.DTOs.CountGroupDTO;

namespace ContadorDeAssistencineitor.Server.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class CountGroupController : ControllerBase
    {
       
        private readonly ILogger<CountGroupController> _logger;
        private readonly IMediator _mediator;

        public CountGroupController(ILogger<CountGroupController> logger, IMediator mediator )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CountGroupDTO.CountGroupMembersDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("getCountGroup")]
        public async Task<ActionResult<CountGroupDTO.CountGroupMembersDTO>> GetCountGroup(Guid guid)
        {
            var result = await _mediator.Send(new GetCountGroup.Query
            {
                Guid = guid,
            });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CountGroupDTO.NewGroupCreated), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("create")]
        public async Task<IActionResult> Create(CountGroupDTO.NewGroup newGroup)
        {
            await _mediator.Send(new Create.Command { 
                Guid = newGroup.Guid,
                UserName = newGroup.Name
            });
            return CreatedAtAction(nameof(Create), new CountGroupDTO.NewGroupCreated(Guid: newGroup.Guid));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("update")]
        public async Task<IActionResult> Update(CountGroupDTO.UpdateGroup updateGroup)
        {
            await _mediator.Send(new Update.Command
            {
                Guid = updateGroup.Guid,
                UserName = updateGroup.Name
            });
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("delete")]
        public async Task<IActionResult> Delete(CountGroupDTO.DeleteGroup deleteGroup)
        {
            await _mediator.Send(new Delete.Command
            {
                Guid = deleteGroup.Guid,

            });
            return Ok();
        }
    }
}