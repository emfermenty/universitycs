/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
class Program
{
    static void Main(string[] args)
    {
        using (var context = new MovieContext())
        {
            var dataService = new add(context);

            // создание
            string genreName = "Фэнтези";
            var actors = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("ДиКаприо", new DateTime(1985, 5, 15)),
                ("Том харди", new DateTime(1990, 8, 20))
            };
            string filmTitle = "Начало";
            string? filmDescription = "Внедрение идей через сны";
            short filmYear = 2010;
            TimeSpan? filmDuration = new TimeSpan(2, 28, 0);
            decimal? filmCashCollection = 535745837.00m;
            float? filmGrade = 8.7f;
            bool? filmEighteenPlus = false;

            // вставка данных во все таблицы
            dataService.InsertData(genreName, actors, filmTitle, filmDescription, filmYear, filmDuration, filmCashCollection, filmGrade, filmEighteenPlus);
            //dataService.AddFilm("Фильм без жанра", "Описание", 2025, null, null, null, null, null);
            // создание
            string genreName2 = "Фэнтези";
            var actors2 = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("ДиКаприо", new DateTime(1985, 5, 15)),
                ("Марк Руффало", new DateTime(1967, 11, 22))
            };
            string filmTitle2 = "Остров проклятых";
            string? filmDescription2 = "Два американских судебных пристава отправляются на один из островов в штате Массачусетс, чтобы расследовать исчезновение пациентки клиники для умалишенных преступников.";
            short filmYear2 = 2009;
            TimeSpan? filmDuration2 = new TimeSpan(2, 18, 0);
            decimal? filmCashCollection2 = 294804195.00m;
            float? filmGrade2 = 8.5f;
            bool? filmEighteenPlus2 = true;

            // вставка данных во все таблицы
            dataService.InsertData(genreName2, actors2, filmTitle2, filmDescription2, filmYear2, filmDuration2, filmCashCollection2, filmGrade2, filmEighteenPlus2);

            Console.WriteLine("Данные успешно добавлены!");
            Console.ReadKey();
            // вывод 
            views a = new views(new MovieContext());
            a.View();
            // изменения
            Console.ReadKey();
            Edit b = new Edit(new MovieContext());
            b.UpdateFilmsByGenre(2, "Без названия", "без описания", 1970, new TimeSpan(0, 0, 0), 0.0m, 0, false);
            b.UpdateActorsByBirthDate(new DateTime(1990, 1, 1), "Updated Actor Name");
            b.UpdateGenresByFilmCount(2, "Updated Genre Name");
            Console.WriteLine("Данные успешно обновлены!");
            a.View();
            Console.ReadKey();
            b.DeleteFilmsByGenreId(2);
            a.View();
            Console.WriteLine("фильмы по жанру удалены!");
            Console.ReadKey();
            b.DeleteActorsByBirthDate(new DateTime(1990, 1, 1));
            a.View();
            Console.WriteLine("актеры удалены!");
            Console.ReadKey();
            b.DeleteGenresByFilmCount(3);
            a.View();
            Console.WriteLine("жанры удалены!");
            Console.ReadKey();
            b.DeleteActorFilmsByActorId(3);
            Console.WriteLine("актер из фильмов удален!");
            a.View();
            Console.ReadKey();
            b.Transaction();
        }
    }
}*/