using System.Linq.Expressions;

class Program{
    public static void Main(){
        bool flag = true;
        while(flag){
            try{
                Console.Write("Введите рубли ");
                uint rub = uint.Parse(Console.ReadLine());
                Console.Write("Введите копейки: ");
                byte kop = byte.Parse(Console.ReadLine());
                money first = new money(rub, kop);
                Console.WriteLine(first);
                Console.Write("Введите кол-во копеек, которое хотите вычесть: ");
                uint kop2 = uint.Parse(Console.ReadLine());
                money newmoney = first.answer(kop2);
                Console.WriteLine(newmoney);
                flag = false;
        } catch {
            Console.WriteLine("Неверные данные ");
        }
        } 
    }
}
