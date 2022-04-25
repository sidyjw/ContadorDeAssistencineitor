using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CountGroup
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Guid { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ILogger<Command> _logger;

            public Handler(ILogger<Command> logger)
            {
                _logger = logger;
            }
            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Novo grupo criado: [Guid {0}]", request.Guid);
                throw new NotImplementedException();
            }
        }
    }
}
