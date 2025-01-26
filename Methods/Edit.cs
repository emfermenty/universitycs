using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class Edit
{
    private readonly MovieContext _context;

    public Edit(MovieContext context)
    {
        _context = context;
    }

    // по жанру фильмов, меняем информацию
    public void UpdateFilmsByGenre(short? genreId, string newTitle, string disk, short year, TimeSpan dur, decimal newCashCollection, float grade, bool eight)
    {
        try
        {
            var filmsToUpdate = _context.Films
                .Where(f => f.GenreId == genreId)
                .ToList();

            foreach (var film in filmsToUpdate)
            {
                film.Title = newTitle;
                film.Description = disk;
                film.Year = year;
                film.Duration = dur;
                film.CashCollection = newCashCollection;
                film.Grade = grade;
                film.eighteenplus = eight;
            }

            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // меняет всех актеров, у кого дата рождения больше необходимой
    public void UpdateActorsByBirthDate(DateTime birthDate, string newName)
    {
        try {
            var actorsToUpdate = _context.Actors
                .Where(a => a.BirthDay > birthDate)
                .ToList();

            foreach (var actor in actorsToUpdate)
            {
                actor.Name = newName;
            }

            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // обновляет жанры там, где количество фильмов выше или равно значению
    public void UpdateGenresByFilmCount(int minFilmCount, string newName)
    {
        try
        {
            var genretoup = _context.Genres.Where(g => g.Films.Count >= minFilmCount).ToList();
            foreach (var genre in genretoup)
            {
                genre.Name = newName;
            }
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
    //удаление фильмов по определенному жанру
    public void DeleteFilmsByGenreId(short genreId)
    {
        try
        {
            var filmsToDelete = _context.Films
                .Where(f => f.GenreId == genreId)
                .ToList();

            _context.Films.RemoveRange(filmsToDelete);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // удаление актеров если дата рождения < определенной
    public void DeleteActorsByBirthDate(DateTime birthDate)
    {
        try
        {
            var actorsToDelete = _context.Actors
                .Where(a => a.BirthDay < birthDate)
                .ToList();

            _context.Actors.RemoveRange(actorsToDelete);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // удаление жанров, если там больше или равно определенного количества фильмов
    public void DeleteGenresByFilmCount(int maxFilmCount)
    {
        try
        {
            var genresToDelete = _context.Genres
                .Where(g => g.Films.Count >= maxFilmCount)
                .ToList();

            foreach (var genre in genresToDelete)
            {
                var filmsToDelete = _context.Films
                    .Where(f => f.GenreId == genre.Id)
                    .ToList();

                _context.Films.RemoveRange(filmsToDelete);
            }

            _context.Genres.RemoveRange(genresToDelete);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // удаляет актера из фильмов
    public void DeleteActorFilmsByActorId(long actorId)
    {
        try
        {
            var actorFilmsToDelete = _context.ActorFilms
                .Where(af => af.ActorId == actorId)
                .ToList();

            _context.ActorFilms.RemoveRange(actorFilmsToDelete);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Ошибка: Конкуренция при обновлении данных. Пожалуйста, попробуйте снова.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Ошибка обновления данных: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
    // транзакция
    public void Transaction()
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                transaction.CreateSavepoint("Savepoint1");
                //добавление фильма
                var newFilm = new Film
                {
                    Title = "Новый Фильм",
                    Year = 2025,
                    GenreId = 1
                };
                _context.Films.Add(newFilm);
                _context.SaveChanges();
                //изменение жанра
                var genre = _context.Genres.Find((short)1);
                if (genre != null)
                {
                    genre.Name = "Обновленный Жанр";
                    _context.SaveChanges();
                }
                transaction.Commit();
                Console.WriteLine("Транзакция успешно завершена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                transaction.RollbackToSavepoint("Savepoint1");
                Console.WriteLine("Откат на точку сохранения выполнен.");

                // откат транзакции
                // transaction.Rollback();
                // Console.WriteLine("Транзакция откатана.");
            }
        }
    }
}