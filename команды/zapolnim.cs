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
            string genreName = "Мелодрама";
            var actors = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("Джозеф Гордон-Левитт", new DateTime(1985, 5, 15)),
                ("Зои Дешанель", new DateTime(1990, 8, 20))
            };
            string filmTitle = "500 дней лета";
            string? filmDescription = "Под разбитое сердце самое то";
            short filmYear = 2009;
            TimeSpan? filmDuration = new TimeSpan(1, 35, 0);
            decimal? filmCashCollection = 60722734.00m;
            float? filmGrade = 7.6f;
            bool? filmEighteenPlus = false;

            // вставка данных во все таблицы
            dataService.InsertData(genreName, actors, filmTitle, filmDescription, filmYear, filmDuration, filmCashCollection, filmGrade, filmEighteenPlus);

            // создание
            string genreName2 = "Драма";
            var actors2 = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("Франсуа Клюзе", new DateTime(1985, 5, 15)),
                ("Омар Си", new DateTime(1967, 11, 22))
            };
            string filmTitle2 = "1+1";
            string? filmDescription2 = "Аристократ на коляске нанимает в сиделки бывшего заключенного. Искрометная французская комедия с Омаром Си";
            short filmYear2 = 2011;
            TimeSpan? filmDuration2 = new TimeSpan(1, 52, 0);
            decimal? filmCashCollection2 = 426588510.00m;
            float? filmGrade2 = 8.8f;
            bool? filmEighteenPlus2 = true;

            // вставка данных во все таблицы
            dataService.InsertData(genreName2, actors2, filmTitle2, filmDescription2, filmYear2, filmDuration2, filmCashCollection2, filmGrade2, filmEighteenPlus2);


            // создание
            string genreName3 = "История";
            var actors3 = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("Уиллем Дефо", new DateTime(1955, 7, 22)),
                ("Чарли Шин", new DateTime(1965, 9, 3))
            };
            string filmTitle3 = "Взвод";
            string? filmDescription3 = "В сентябре 1967 года куда-то в приграничный район между Вьетнамом и Камбоджей прибыл рядовой 25-го пехотного полка Крис Тэйлор";
            short filmYear3 = 1986;
            TimeSpan? filmDuration3 = new TimeSpan(2, 0, 0);
            decimal? filmCashCollection3 = 138545632.00m;
            float? filmGrade3 = 8.0f;
            bool? filmEighteenPlus3 = false;

            // вставка данных во все таблицы
            dataService.InsertData(genreName3, actors3, filmTitle3, filmDescription3, filmYear3, filmDuration3, filmCashCollection3, filmGrade3, filmEighteenPlus3);

            // создание
            string genreName4 = "Биография";
            var actors4 = new List<(string actorName, DateTime actorBirthDay)>
            {
                ("Киллиан Мерфи", new DateTime(1985, 5, 15)),
                ("Эмили Блант", new DateTime(1967, 11, 22))
            };
            string filmTitle4 = "Оппенгеймер";
            string? filmDescription4 = "История жизни американского физика-теоретика Роберта Оппенгеймера, который во времена Второй мировой войны руководил Манхэттенским проектом — секретными разработками ядерного оружия.";
            short filmYear4 = 2023;
            TimeSpan? filmDuration4 = new TimeSpan(3, 0, 0);
            decimal? filmCashCollection4 = 975594978.00m;
            float? filmGrade4 = 8.1f;
            bool? filmEighteenPlus4 = false;

            // вставка данных во все таблицы
            dataService.InsertData(genreName4, actors4, filmTitle4, filmDescription4, filmYear4, filmDuration4, filmCashCollection4, filmGrade4, filmEighteenPlus4);

        }
    }
}*/