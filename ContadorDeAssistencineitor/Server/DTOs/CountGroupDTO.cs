namespace ContadorDeAssistencineitor.Server.DTOs
{
    public class CountGroupDTO
    {
        public record NewGroup(Guid Guid, string Name);

        public record NewGroupCreated(Guid Guid);
    }
}
