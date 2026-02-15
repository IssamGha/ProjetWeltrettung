using Microsoft.EntityFrameworkCore;

namespace ProjetWeltrettung.Models
{
    public class ProjetWeltrettungContext : DbContext
    {
        public ProjetWeltrettungContext(DbContextOptions<ProjetWeltrettungContext> options) : base(options) { }



        public DbSet<Weltretter> Weltretter { get; set; }
        public DbSet<Aggressor> Aggressoren { get; set; }
        public DbSet<Held> Helden { get; set; }
        public DbSet<Bedrohung> Bedrohungen { get; set; }
    }

}
