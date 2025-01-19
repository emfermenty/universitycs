/*using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        using (var context = new MovieContext())
        {
            // считывание данных
            var films = context.Films.Include(f => f.Genre).Include(f => f.Actors).ToList();
            if (films.Count == 0)
            {
                Console.WriteLine("Нет доступных фильмов в базе данных.");
            }
            else
            {
                foreach (var film in films)
                {
                    Console.WriteLine($"Фильм: {film.Title}, Жанр: {film.Genre.Name}");
                    foreach (var actor in film.Actors)
                    {
                        Console.WriteLine($"  Актеры: {actor.Name}");
                    }
                }
            }

            // 2. Вставка данных
            var newGenre = new Genre { Name = "Comedy" };
            var newFilm2 = new Film { Title = "New Comedy Film", Genre = newGenre };
            newFilm2.Actors.Add(new Actor { Name = "New Actor" });
            context.Genres.Add(newGenre);
            context.Films.Add(newFilm2);
            context.SaveChanges();

            // 3. Изменение данных
            var filmToUpdate = context.Films.FirstOrDefault(f => f.Title == "First Action Film");
            if (filmToUpdate != null)
            {
                filmToUpdate.Title = "Updated Film Title";
                context.SaveChanges();
            }

            // 4. Удаление данных
            var genreToDelete = context.Genres.FirstOrDefault(g => g.Name == "Drama");
            if (genreToDelete != null)
            {
                context.Genres.Remove(genreToDelete);
                context.SaveChanges();
            }

            // 5. Транзакции
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // a. Точка сохранения
                    transaction.CreateSavepoint("BeforeInsert");

                    // Вставка данных в транзакции
                    var anotherGenre = new Genre { Name = "Thriller" };
                    var anotherFilm = new Film { Title = "Another Thriller Film", Genre = anotherGenre };
                    anotherFilm.Actors.Add(new Actor { Name = "Another Actor" });
                    context.Genres.Add(anotherGenre);
                    context.Films.Add(anotherFilm);
                    context.SaveChanges();

                    // b. Успешное завершение транзакции
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // c. Откат транзакции
                    transaction.RollbackToSavepoint("BeforeInsert");
                }
            }

            // 6. Обработка ошибок
            try
            {
                // Некорректная модификация данных
                var invalidFilm = context.Films.FirstOrDefault(f => f.Title == "Invalid Film");
                if (invalidFilm != null)
                {
                    invalidFilm.Title = null; // Это вызовет ошибку
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Ошибка при обновлении данных: " + ex.Message);
            }
        }
    }
}*/