using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CountGroup
    {
        [Key]
        public Guid Guid { get; set; }
        public List<GroupMember> GroupMembers { get; set; } = new();
    }
}