using Application.Contracts.Repositories;
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
            public string Name { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ILogger<Command> _logger;
            private readonly ICountGroup _countGroup;

            public Handler(ILogger<Command> logger, ICountGroup countGroup)
            {
                _logger = logger;
                _countGroup = countGroup;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _countGroup.CreateAsync(request.Guid, request.Name);
                _logger.LogInformation("Novo grupo criado: [Guid {0}]", request.Guid);
                
                return Unit.Value;
            }
        }
    }
}
