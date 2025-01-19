using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        using (var context = new MovieContext())
        {
            while (true)
            {

                Console.WriteLine("Введите действие:\n 1. Считывание данных. \n 2. Вставка данных. \n 3. Изменение данных. \n 4. Удаление данных. \n 5. транзакции");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
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
                        break;
                    // 2. Вставка данных
                    case 2:
                        Console.WriteLine("Введите действие: 1. добавить жанр 2. добавить актера. 3. добавить фильм");
                        int add = int.Parse(Console.ReadLine());
                        switch (add)
                        {
                            case 1:
                                Console.Write("Введите название жанра: ");
                                string genrename = Console.ReadLine();
                                Genre genre = new Genre { Name = genrename };
                                context.Genres.Add(genre);
                                context.SaveChanges();
                                Console.WriteLine("Жанр добавлен");
                                break;
                            case 2:
                                Console.Write("Введите имя актера:");
                                string actorname = Console.ReadLine();
                                Actor newactor = new Actor { Name = actorname };
                                context.Actors.Add(newactor);
                                context.SaveChanges();
                                Console.WriteLine("Актер добавлен");
                                break;

                            case 3:
                                Console.Write("Введите название фильма: ");
                                string filmname = Console.ReadLine();
                                Console.Write("Введите id жанра: ");
                                int genreid = int.Parse(Console.ReadLine());
                                Genre genr = context.Genres.Find(genreid);
                                if (genr == null)
                                {
                                    Console.WriteLine("Жанр не найден");
                                    break;
                                }
                                Film newfilm = new Film { Title = filmname, Genre = genr };
                                Console.WriteLine("Введите количество актеров");
                                int actorcount = int.Parse(Console.ReadLine());
                                for (int i = 0; i < actorcount; i++)
                                {
                                    Console.Write($"Введите имя актера {i + 1}: ");
                                    string actorName = Console.ReadLine();
                                    newfilm.Actors.Add(new Actor { Name = actorName });
                                }
                                context.Films.Add(newfilm);
                                context.SaveChanges();
                                Console.WriteLine("Фильм добавлен");
                                break;
                            default:
                                Console.WriteLine("Неверные данные");
                                break;
                        }
                        break;
                    //3. Изменение данных
                    case 3:
                        Console.WriteLine("Введите действие: 1. изменить жанр 2. изменить актера. 3. изменить фильм");
                        int update = int.Parse(Console.ReadLine());
                        switch (update) {
                            case 1:
                                
                            break;

                            case 2:

                            break;

                            case 3:
                                Console.Write("Введите id фильма для изменения: ");
                                int filmIdToUpdate = int.Parse(Console.ReadLine());
                                Film filmToUpdate = context.Films.FirstOrDefault(f => f.FilmId == filmIdToUpdate);
                                if (filmToUpdate != null)
                                {
                                    Console.Write("Введите новое название фильма: ");
                                    filmToUpdate.Title = Console.ReadLine();
                                    context.SaveChanges();

                                }
                                break;

                                break;
                        }
                        /*var filmToUpdate = context.Films.FirstOrDefault(f => f.Title == "First Action Film");
                        if (filmToUpdate != null)
                        {
                            filmToUpdate.Title = "Updated Film Title";
                            context.SaveChanges();
                        } */
                        
                        break;
                    case 4:
                        // 4. Удаление данных
                        var genreToDelete = context.Genres.FirstOrDefault(g => g.Name == "Drama");
                        if (genreToDelete != null)
                        {
                            context.Genres.Remove(genreToDelete);
                            context.SaveChanges();
                        }
                        break;
                    case 5:
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
                        break;
                    case 6:
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
                        break;
                    default:
                        Console.WriteLine("неверный номер");
                        break;
                }
            }
        }
    }
}