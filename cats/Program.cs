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
    }
}