using Application.Contracts.Repositories;
using Domain;
using MediatR;
using static ContadorDeAssistencineitor.Application.DTOs.CountGroupDTO;

namespace Application.CountGroup.Queries
{
    
    public class GetCountGroup
    {
        public class Query : IRequest<CountGroupMembersDTO>
        {
            public Guid Guid { get; set; }
        }

        public class Handler : IRequestHandler<Query, CountGroupMembersDTO>
        {
            private readonly ICountGroup _countGroup;

            public Handler(ICountGroup countGroup)
            {
                _countGroup = countGroup;
            }
            public async Task<CountGroupMembersDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var countGroup = await _countGroup.GetAsync(request.Guid);
                return new CountGroupMembersDTO(countGroup.GroupMembers);
            }
        }
    }
}