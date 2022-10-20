namespace mywebapi.Classes
{
    public class Move
    {
        public int id { get; set; }
        public Move move { get; set; }
        public List<VersionGroupDetail> version_group_details { get; set; }
    }
}
