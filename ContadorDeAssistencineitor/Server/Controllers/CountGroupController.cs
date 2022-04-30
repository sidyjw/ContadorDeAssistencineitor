using ContadorDeAssistencineitor.Server.DTOs;
using ContadorDeAssistencineitor.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CountGroup.Create;

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

        [HttpPost]
        [ProducesResponseType(typeof(CountGroupDTO.NewGroupCreated), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("create")]
        public async Task<IActionResult> Create(CountGroupDTO.NewGroup newGroup)
        {
            await _mediator.Send(new Command { 
                Guid = newGroup.Guid,
                UserName = newGroup.Name
            });
            return CreatedAtAction(nameof(Create), new CountGroupDTO.NewGroupCreated(Guid: newGroup.Guid));
        }
    }
}