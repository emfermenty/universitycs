using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class views
{
    private readonly MovieContext _context;

    public views(MovieContext context)
    {
        _context = context;
    }
    public void View()
    {
        using (var context = new MovieContext())
        {
            var films = context.Films
                .Include(f => f.Genre)
                .Include(f => f.ActorFilms)
                    .ThenInclude(af => af.Actor)
                .AsNoTracking() 
                .ToList();

            if (films.Count == 0)
            {
                Console.WriteLine("Нет доступных фильмов в базе данных.");
            }
            else
            {
                foreach (var film in films)
                {
                    Console.WriteLine($"Фильм: {film.Title}, Жанр: {film.Genre?.Name}, Год: {film.Year}, Продолжительность {film.Duration}, Касса {film.CashCollection}");
                    foreach (var actorFilm in film.ActorFilms)
                    {
                        Console.WriteLine($"  Актеры: {actorFilm.Actor.Name}");
                    }
                }
            }
        }
    }
}