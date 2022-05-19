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
        [Route("getCountGroup/{guid:guid}")]
        public async Task<ActionResult<CountGroupDTO.CountGroupMembersDTO>> GetCountGroup(Guid guid)
        {
            var result = await _mediator.Send(new GetCountGroup.Query
            {
                Guid = guid,
            });

            if (!result.IsSuccess) return NotFound(result.Message);

            return Ok(result.Value);
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

        [HttpPatch]
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

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("addNewMember")]
        public async Task<IActionResult> AddNewMember(CountGroupDTO.NewGroupMember newGroupMember)
        {
            var result = await _mediator.Send(new AddNewMember.Command
            {
                Guid = newGroupMember.Guid,
                UserName = newGroupMember.Name
            });

            if (!result.IsSuccess) return NotFound(result.Message);

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