using System.Linq.Expressions;
using System;
class Program{
    public static void Main(){
        bool aha = true;
        while(aha){
            try{
            Console.Write("Введите рубли для первого кошелька: ");
            uint r1 = uint.Parse(Console.ReadLine());
            Console.Write("Введите копейки для первого кошелька: ");
            byte k1 = byte.Parse(Console.ReadLine());
            money money1 = new money(r1, k1);
            Console.WriteLine(money1.ToString());
            Console.Write("Введите рубли для второго кошелька: ");
            uint r2 = uint.Parse(Console.ReadLine());
            Console.Write("Введите копейки для второго кошелька: ");
            byte k2 = byte.Parse(Console.ReadLine());
            money money2 = new money(r2, k2);
            money1 -= money2;
            Console.WriteLine("после вычитания в первом кошельке осталось: " + money1.ToString()); // 4 руб. 75 коп.
        
            money1++; 
            Console.WriteLine("Переопределили унарный оператор, теперь ++ добавляет копейку " + money1.ToString()); // 10 руб. 51 коп.
        
            money1--; 
            Console.WriteLine(" -- вычитает копейку " + money1.ToString()); // 0 руб. 50 коп.

            uint rubles = (uint)money1;
            Console.WriteLine("Преобразование в uint: " + rubles);

            bool isNonZero = money1; 
            Console.WriteLine("Преобразование в bool " + isNonZero); 
            aha = false;
        } catch {
            Console.WriteLine("Неверные данные ");
        }
        }
    } 
}
