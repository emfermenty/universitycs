using System;

class Program{
    public static void Main(){
        bool s = true;
        Array<int> a = null;
        while(s){
        try{
        Console.Write("Задание 1.1: ");
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("столбцов: ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Вывод первого задания: ");
        a = new Array<int>(n,m, 'o');
        a.PrintArray();
        s = false;
        } catch {
            Console.WriteLine("неверные данные");
            }
        }
        s = true;
        Array<int> b = null;
        while(s){
            try{
            Console.Write("Задание 1.2: ");
            Console.WriteLine("Введите размерность массива N x N: ");
            int nn = int.Parse(Console.ReadLine());
            Console.WriteLine("Вывод второго задания: ");
            b = new Array<int>(nn);
            b.PrintArray();
            s = false;
            } catch{
                Console.WriteLine("неверные данные");
            }
        } s = true;
        Array<int> c = null;
        while(s){
            try{
                Console.Write("Задание 1.3: ");
                Console.WriteLine("Введите размерность массива: ");
                int nnn = int.Parse(Console.ReadLine());
                int nnnn = int.Parse(Console.ReadLine());
                Console.WriteLine("Выведте значение x: ");
                int x = int.Parse(Console.ReadLine());
                c = new Array<int>(nnn, nnnn, x);
                c.PrintArray();
                s = false;
            } catch{
                Console.WriteLine("Неверные данные");
            }
        }
        //задание 2
        s = true;
        Console.Write("Задание 2: ");
        while(s){
            Array<bool> z = new Array<bool>();
            s = false;
        }
        //задание 3
        Console.WriteLine("Задание 3, Транспонирование: ");
        a.Transpose();
        Console.WriteLine(a.ToString());
        a += b - (c*3);
        Console.WriteLine("Результат:");
        Console.WriteLine(a.ToString());
        Console.WriteLine("начинаем 4-8, введите что-то чтобы продолжить");
        Console.ReadKey();
        Console.Write("Задание 4: ");
        Files.First();
        Console.Write("Задание 5: ");
        Files.touchtoysfile();
        Console.WriteLine("Ответ на второе 5-e задание: " + Files.maxtoy());
        Files.zap();
        Files.mission6();
        Console.Write("Задание 7: ");
        Files.zapfor7();
        Files.calc7();
        Files.zapfor8();
    }
}
