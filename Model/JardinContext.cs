using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JardinContext : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<GroupeJardin> GroupesJardin { get; set; }
        public JardinContext()
            : base(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=ApiFreeGarden;")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                        .HasMany<GroupeJardin>(p => p.GroupesJardin)
                        .WithMany(g => g.Membres)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MembreRefId");
                            cs.MapRightKey("GroupeJardinRefId");
                            cs.ToTable("PersonneGroupeJardin");
                        });
        }
    }
}
