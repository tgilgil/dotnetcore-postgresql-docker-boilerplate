using Boilerplate.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.API.Database
{
    public class PokemonsContext : DbContext
    {
        public PokemonsContext(DbContextOptions<PokemonsContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
