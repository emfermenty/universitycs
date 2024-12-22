using System;
class Program
{
    public static void Main()
    {
        Cat barsik = new Cat("Барсик");
        CountOfMeow countedBarsik = new CountOfMeow(barsik);
        
        countedBarsik.Meow();
        countedBarsik.Meow(3);
        
        lev dog = new lev("Волк");
        CountOfMeow countedDog = new CountOfMeow(dog);
        countedDog.Meow();
        
        IMeowable[] meowables = new IMeowable[] { countedBarsik, countedDog };
        Meowing.gomeow(meowables);
        
        Console.WriteLine($"Количество мяуканий кота: {countedBarsik.MeowCount}");
        Console.WriteLine($"Количество мяуканий льва: {countedDog.MeowCount}");
		
		//1
		Fraction a = new Fraction(2, 6);
        Fraction b = new Fraction(3, 8);
        Console.WriteLine($"{a.ToString()} + {b.ToString()} = {a + b}");
        Console.WriteLine($"{a.ToString()} - {b.ToString()} = {a - b}");
        Console.WriteLine($"{a.ToString()} * {b.ToString()} = {a * b}");
        Console.WriteLine($"{a.ToString()} / {b.ToString()} = {a / b}");
        Fraction c = new Fraction(4, 9);
        Console.WriteLine($"(a + b) * c - 5 = {(a + b) * c - 5}");
        Fraction d = new Fraction(1, 3);
        // 2
        Console.WriteLine(a.Equals(d));
        //4
        a.setNumerator(2);
        a.setDenominator(5);
        Console.WriteLine($"Новая дробь a: {a}"); // 2/5
        Console.WriteLine($"Вещественная: {a.GetValue()}"); // 0.4
        
        Fraction resultAdd = a + b;  // 2/5 + 2/3
        Console.WriteLine($"{a} + {b} = {resultAdd}");  // 2/5 + 3/8 = 31/40
        
        // Проверка кэширования
        Console.WriteLine($"Результат дроби {resultAdd}: {resultAdd.GetValue()}"); // 0,775
    }
}