using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext
{
    public DbSet<Film> Films { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ActorFilm> ActorFilms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ActorFilm>()
            .HasKey(af => new { af.ActorId, af.FilmId });

        modelBuilder.Entity<ActorFilm>()
            .HasOne(af => af.Actor)
            .WithMany(a => a.ActorFilms)
            .HasForeignKey(af => af.ActorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ActorFilm>()
            .HasOne(af => af.Film)
            .WithMany(f => f.ActorFilms)
            .HasForeignKey(af => af.FilmId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=master;Database=test");
    }
}
