using System;

class Program{
    public static void Main(){
        Console.WriteLine("Введите true или false");
        bool wh= true;
        while(wh){
            try{
            Console.Write("Первое поле: ");
            bool a = bool.Parse(Console.ReadLine());
            Console.Write("Второе поле: ");
            bool b = bool.Parse(Console.ReadLine());
            logic first = new logic(a, b);
            Console.WriteLine("Импликация: " + first.implication());
            Console.WriteLine(first.ToString());
            logic copy = new logic(first);
            Console.WriteLine("Копия: " + copy.ToString());
            wh = false;
            } catch {
                Console.WriteLine("Введите заново true или false");
            }
        }
        bool con = true;
        while(con){
            try{
                Console.WriteLine("Дальше для наследуемого класса(4 поля): ");
                Console.Write("Первое поле(x): ");
                bool c = bool.Parse(Console.ReadLine());
                Console.Write("Второе поле(y): ");
                bool d = bool.Parse(Console.ReadLine());
                Console.Write("Третье поле(k): ");
                bool k = bool.Parse(Console.ReadLine());
                Console.Write("Четвертое поле(z): ");
                bool z = bool.Parse(Console.ReadLine());
                extendslogic test = new extendslogic(c, d, k, z);
                Console.WriteLine("Наследуемый класс имеет поля: " + test.ToString());
                Console.WriteLine("Коньюнкция полей k и z: " + test.con());
                Console.WriteLine("Дизьюнкция полей k и z: " + test.diz());
                Console.WriteLine("Результат работы формулы (x->y) && (k || z): " + test.formula());
                con = false;
            } catch {
                Console.WriteLine("Введите заново true или false");
            }
        }
    }
}
