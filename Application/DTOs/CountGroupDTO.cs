using Domain;

namespace ContadorDeAssistencineitor.Application.DTOs
{
    public class CountGroupDTO
    {
        public record NewGroup(Guid Guid, string Name);
        public record NewGroupCreated(Guid Guid);

        public record class CountGroupMembersDTO(List<GroupMember> CountGroup);

        public record UpdateGroup(Guid Guid, string Name);
        public record UpdatedGroup(CountGroup countGroup);

        public record DeleteGroup(Guid Guid);
    }
}
