using Microsoft.EntityFrameworkCore;
using mywebapi.Classes;
using System.Reflection.Metadata;

namespace mywebapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Pokemon> _pokemons { get; set; }
       
    }
}
