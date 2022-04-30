using ContadorDeAssistencineitor.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CountGroup.Create;

namespace ContadorDeAssistencineitor.Server.Controllers
{
    public record NewGroup(Guid Guid, string Name);
    
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
        [Route("create")]
        public async Task<IActionResult> Create(NewGroup newGroup)
        {
            await _mediator.Send(new Command { 
                Guid = newGroup.Guid,
                Name = newGroup.Name
            });
            return CreatedAtAction(nameof(Create), new { Guid = newGroup.Guid });
        }
    }
}