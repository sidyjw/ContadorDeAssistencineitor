using Application.Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CountGroup.Commands
{
    public class Update
    {
        public class Command : IRequest
        {
            public Guid Guid { get; set; }
            public string UserName { get; set; }
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

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var countGroup = await _countGroup.GetAsync(command.Guid);
                var index = countGroup.GroupMembers.FindIndex(x => x.Name == command.UserName);

                countGroup.GroupMembers[index].Count += 1;
                await _countGroup.UpdateAsync(countGroup);
                
                return Unit.Value;
            }
        }
    }
}
