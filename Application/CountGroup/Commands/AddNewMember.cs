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
    public class AddNewMember
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

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var countGroup = await _countGroup.GetAsync(request.Guid);

                if(countGroup.GroupMembers.Count == 0)
                {
                    return Unit.Value;
                }

                countGroup.GroupMembers.Add(new() { Name = request.UserName });

                await _countGroup.UpdateAsync(countGroup);

                return Unit.Value;
            }
        }
    }
}
