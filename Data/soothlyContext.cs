using Microsoft.EntityFrameworkCore;
using soothlyAPI.Models;

namespace soothlyAPI.Data
{
    public class SoothlyContext : DbContext
    {
        public SoothlyContext(DbContextOptions<SoothlyContext> options) : base (options)
        {}

        public DbSet<Usuarios> Usuarios  {get; set;}
        public DbSet<TiposDeArtigos> TiposDeArtigos {get; set;}
        public DbSet<Artigos> Artigos {get; set;}
    }
}