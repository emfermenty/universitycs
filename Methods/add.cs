using System;
using System.Collections.Generic;
using System.Linq;

public class add
{
    private readonly MovieContext _context;

    public add(MovieContext context)
    {
        _context = context;
    }

    // добавление жанра
    public void AddGenre(string name)
    {
        var exist = _context.Genres.FirstOrDefault(g => g.Name.ToLower() == name.ToLower());
        if (exist != null) {
            Console.WriteLine("Дубликат жанра");
            return;
        }
        Genre genre = new Genre { Name = name};
        _context.Genres.Add(genre);
        _context.SaveChanges();
     }


    // добавление / получение актера
    public Actor GetOrAddActor(string name, DateTime birthDay)
    {
        var existingActor = _context.Actors.FirstOrDefault(a => a.Name == name);
        if (existingActor != null)
        {
            return existingActor; // возвращаем существующего актера
        }

        var newActor = new Actor { Name = name, BirthDay = birthDay };
        _context.Actors.Add(newActor);
        _context.SaveChanges();
        return newActor; // возвращаем нового актера
    }

    // добавление фильма
    public void AddFilm(string title, string? description, short year, TimeSpan? duration, decimal? cashCollection, float? grade, bool? eighteenPlus, short? genreId)
    {
        var film = new Film
        {
            Title = title,
            Description = description,
            Year = year,
            Duration = duration,
            CashCollection = cashCollection,
            Grade = grade,
            eighteenplus = eighteenPlus,
            GenreId = genreId
        };
        _context.Films.Add(film);
        _context.SaveChanges();
    }

    // связка актера и фильма
    public void AddActorFilm(long actorId, int filmId)
    {
        var actorFilm = new ActorFilm { ActorId = actorId, FilmId = filmId };
        _context.ActorFilms.Add(actorFilm);
        _context.SaveChanges();
    }

    // Добавление во все таблицы
    public void InsertData(string genreName, List<(string actorName, DateTime actorBirthDay)> actors, string filmTitle, string? filmDescription, short filmYear, TimeSpan? filmDuration, decimal? filmCashCollection, float? filmGrade, bool? filmEighteenPlus)
    {
        // добавление жанра
        AddGenre(genreName);
        var genre = _context.Genres.FirstOrDefault(g => g.Name == genreName);
        // добавляе фильм
        AddFilm(filmTitle, filmDescription, filmYear, filmDuration, filmCashCollection, filmGrade, filmEighteenPlus, genre?.Id);

        // получение фильма
        var film = _context.Films.FirstOrDefault(f => f.Title == filmTitle);

        // связываем актеров и фильмы
        if (film != null)
        {
            foreach (var (actorName, actorBirthDay) in actors)
            {
                var actor = GetOrAddActor(actorName, actorBirthDay); // Получаем или добавляем актера
                AddActorFilm(actor.Id, film.Id); // Связываем актера с фильмом
            }
        }
    }
}