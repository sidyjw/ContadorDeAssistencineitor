using Application.Common;
using Application.Contracts.Repositories;
using MediatR;
using static ContadorDeAssistencineitor.Application.DTOs.CountGroupDTO;

namespace Application.CountGroup.Queries
{
    
    public class GetCountGroup
    {
        public class Query : IRequest<Result<CountGroupMembersDTO>>
        {
            public Guid Guid { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CountGroupMembersDTO>>
        {
            private readonly ICountGroup _countGroup;

            public Handler(ICountGroup countGroup)
            {
                _countGroup = countGroup;
            }
            public async Task<Result<CountGroupMembersDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countGroup = await _countGroup.GetAsync(request.Guid);
                if (countGroup is null)
                {
                    return Result<CountGroupMembersDTO>.Failure("Grupo não encontrado.");
                }

                return Result<CountGroupMembersDTO>.Success(new CountGroupMembersDTO(countGroup.GroupMembers));
            }
        }
    }
}