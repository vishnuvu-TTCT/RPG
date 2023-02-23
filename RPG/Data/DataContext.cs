


namespace RPG.Data
{
    public class DataContext :DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Damage = 70 },
                new Skill { Id = 2, Name = "Blade", Damage = 100 },
                new Skill { Id = 3, Name = "Rocket Launcher", Damage = 200 }
                );
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Skill> Skills => Set<Skill>();

    }
}
