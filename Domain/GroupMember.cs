namespace Domain
{
    public class GroupMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public CountGroup CountGroup { get; set; }
    }
}