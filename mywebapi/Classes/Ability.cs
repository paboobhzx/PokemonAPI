using Microsoft.EntityFrameworkCore;

namespace mywebapi.Classes
{
    
    public class Ability
    {
        public int id { get; set; }
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
