using System.ComponentModel.DataAnnotations;

namespace mywebapi.Classes
{
    public class VersionGroupDetail
    {
        [Key]
        public int id;
        public int level_learned_at { get; set; }
        public MoveLearnMethod move_learn_method { get; set; }
        public VersionGroup version_group { get; set; }
    }
}
