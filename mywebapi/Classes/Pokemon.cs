using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace mywebapi.Classes
{
    public class Pokemon
    {
        [Key]
        public int id { get; set; }
        public List<Ability> abilities { get; set; }
        public int base_experience { get; set; }
        public List<Move> moves { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public Species species { get; set; }
        public List<Stat> stats { get; set; }
        public int weight { get; set; }
    }
  
    public class OfficialArtwork
    {
        public string front_default { get; set; }
    }
    




   
}
