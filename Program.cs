using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;
using System.Xml.Schema;

class Program{
    public static void Main(){
        Program program = new Program();
        Console.Write("Выберите тему задания: \n Задание 1 - методы \n Задание 2 - условия \n Задание 3 - Циклы \n Задание 4 - Массивы ");
        string qus = Console.ReadLine();
        int quss = Convert.ToInt32(qus);
        switch(quss){
            case 1:
            Console.Write("Выберите номер задания: ");
            string xx = Console.ReadLine();
            int y = Convert.ToInt32(xx);
            switch(y){
                case 1:
                Console.Write("Введите переменную(double): ");
                string input = Console.ReadLine();
                double x = Convert.ToDouble(input);
                Console.WriteLine(program.fraction(x));
                break;
                case 3:
                Console.Write("Введите переменную(char): ");
                string inputt = Console.ReadLine();
                char yy = Convert.ToChar(inputt);
                Console.WriteLine(program.charToNum(yy));
                break;
                case 5:
                Console.Write("Введите переменную(int): ");
                string inputtt = Console.ReadLine();
                int yyy = Convert.ToInt32(inputtt);
                Console.WriteLine(program.is2Digits(yyy));
                break;
                case 7:
                Console.Write("Введите переменную a: ");
                string inputttt= Console.ReadLine();
                int yyyy = Convert.ToInt32(inputttt);
                Console.Write("Введите переменную b: ");
                string inputtttt= Console.ReadLine();
                int yyyyy = Convert.ToInt32(inputtttt);
                Console.Write("Введите переменную num: ");
                string inputttttt= Console.ReadLine();
                int yyyyyy = Convert.ToInt32(inputttttt);
                Console.WriteLine(program.isInRange(yyyy, yyyyy, yyyyyy));
                break;
                case 9:
                Console.Write("Введите переменную a: ");
                string inputtttttt= Console.ReadLine();
                int yyyyyyy = Convert.ToInt32(inputtttttt);
                Console.Write("Введите переменную b: ");
                string inputttttttt = Console.ReadLine();
                int yyyyyyyy = Convert.ToInt32(inputttttttt);
                Console.Write("Введите переменную c: ");
                string inputtttttttt = Console.ReadLine();
                int yyyyyyyyy = Convert.ToInt32(inputtttttttt);
                Console.WriteLine(program.isInRange(yyyyyyy, yyyyyyyy, yyyyyyyyy));
                break;
                default: 
                Console.WriteLine("Такого не существует");
                break;
            }
            break;
            case 2:
            Console.WriteLine("Выберите номер задания ");
            string xxx = Console.ReadLine();
            int c = Convert.ToInt32(xxx);
            switch(c){
                case 1:
                Console.Write("Введите x: ");
                string iinput = Console.ReadLine();
                int cc = Convert.ToInt32(iinput);
                Console.WriteLine(program.abs(cc));
                break;
                case 3:
                Console.Write("Введите x: ");
                string iiinput = Console.ReadLine();
                int ccc = Convert.ToInt32(iiinput);
                Console.WriteLine(program.is35(ccc));
                break;
                case 5:
                Console.Write("Введите число x: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите число y: ");
                int w = int.Parse(Console.ReadLine());
                Console.Write("Введите число z: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine(program.max3(x, w, z));
                break;
                case 7:
                Console.Write("Введите x: ");
                int xxxx = int.Parse(Console.ReadLine());
                Console.Write("Введите y: ");
                int xxxxx = int.Parse(Console.ReadLine());
                Console.WriteLine(program.sum2(xxxx, xxxxx));
                break;
                case 9:
                Console.Write("Введите номер дня недели: ");
                int t = int.Parse(Console.ReadLine());
                Console.WriteLine(program.day(t));
                break;
                default:
                Console.WriteLine("Такого не существует");
                break;
            }
            break;
            case 3:
            Console.Write("Выберите номер задания: ");
            int k = int.Parse(Console.ReadLine());
            switch(k){
                case 1:
                Console.Write("Введите число: ");
                int kk = int.Parse(Console.ReadLine());
                Console.WriteLine(program.listNums(kk));
                break;
                case 3:
                Console.Write("Введите число: ");
                int kkk = int.Parse(Console.ReadLine());
                Console.WriteLine(program.chet(kkk));
                break;
                case 5:
                Console.Write("Введите число: ");
                int kkkk = int.Parse(Console.ReadLine());
                Console.WriteLine(program.numLen(kkkk));
                break;
                case 7:
                Console.Write("Введите число: ");
                int kkkkk = int.Parse(Console.ReadLine());
                program.square(kkkkk);
                break;
                case 9:
                Console.Write("Введите число: ");
                int kkkkkk = int.Parse(Console.ReadLine());
                program.rightTriangle(kkkkkk);
                break;
            }
            break;
            case 4:
            Console.Write("Выберите номер задания: ");
            int o = int.Parse(Console.ReadLine());
            switch(o){
                case 1:
                Console.Write("Введите размер массива: ");
                int raz = int.Parse(Console.ReadLine());
                int[] oo = new int[raz];
                for(int i = 0; i < raz; i++){
                    Console.Write($"Введите {i} эллмент массива: ");
                    oo[i] = int.Parse(Console.ReadLine());
                }
                    Console.Write("Введите число, входящее в массив: ");
                    int ooo = int.Parse(Console.ReadLine());
                    Console.WriteLine(program.findFirst(oo, ooo));
                break;
                case 3:
                Console.Write("Введите размер массива: ");
                int razz = int.Parse(Console.ReadLine());
                int[] oooo = new int[razz];
                for(int i = 0; i < razz; i++){
                    Console.Write($"Введите {i} эллмент массива: ");
                    oooo[i] = int.Parse(Console.ReadLine());
                }
                    Console.WriteLine(program.maxAbs(oooo));
                break;
                case 5:
                    Console.Write("Введите размер первого массива: ");
                    int razzz = int.Parse(Console.ReadLine());
                    int[] ooooo = new int[razzz];
                    for(int i = 0; i < razzz; i++){
                        Console.Write($"Введите {i} эллемент первого массива: ");
                        ooooo[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите размер второго массива: ");
                    int razzzz = int.Parse(Console.ReadLine());
                    int[] oooooo = new int[razzzz];
                    for(int i = 0; i < razzzz; i++){
                        Console.Write($"Введите {i} эллемент второго массива: ");
                        oooooo[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите индекс после которого осуществляется вставка: ");
                    int rez = int.Parse(Console.ReadLine());
                    int[] otv = program.add(ooooo, oooooo, rez);
                    for(int i = 0; i < otv.Length; i++){
                        Console.Write(otv[i] + " ");
                    }
                break;
                case 7:
                Console.Write("Введите размер массива: ");
                int raaz = int.Parse(Console.ReadLine());
                int[] oa = new int[raaz];
                for(int i = 0; i < raaz; i++){
                    Console.Write($"Введите {i} эллмент массива: ");
                    oa[i] = int.Parse(Console.ReadLine());
                }
                int[] ao = program.reverseBack(oa);
                for(int i = 0; i < oa.Length; i++){
                    Console.Write(ao[i] + " ");
                }
                break;
                case 9:
                Console.Write("Введите размер массива: ");
                int rraz = int.Parse(Console.ReadLine());
                int[] oao = new int[rraz];
                for(int i = 0; i < rraz; i++){
                    Console.Write($"Введите {i} эллмент массива: ");
                    oao[i] = int.Parse(Console.ReadLine());
                }
                    Console.Write("Введите x: ");
                    int osoo = int.Parse(Console.ReadLine());
                    int[] ks = program.findAll(oao, osoo);
                    for(int i = 0; i < ks.Length; i++){
                        Console.Write(ks[i] + " ");
                    }
                break;
            }
            break;
            default:
            Console.WriteLine("Такого не существует");
            break;
        }
    }
    public double fraction (double x){
        int y = (int) x;
        return x-y;
    }
    public int charToNum (char x){
        if(x >= '0' && x <= '9'){
           return x-'0';} else {
            throw new ArgumentException("Введите число от 0 до 9");
        }
    }
    public bool is2Digits (int x){
        return x>=10 && x <= 99;
    }
    public bool isInRange (int a, int b, int num){
        int lower = a < b ? a : b;
        int upper = a > b ? a : b;
        return num >= lower && num <= upper;
    }
    public bool isEqual(int a, int b, int c){
        return a == b && b == c;
    }
    public int abs (int x){
        if(x >= 0){
            return x;
        } else {
            x = -x;
            return x;
        }
    }
    public bool is35 (int x){
        if(x % 5 == 0 && x % 3 != 0){
            return true;
        }
        if(x % 3 == 0 && x % 5 != 0){
            return true;
        } else {
            return false;
        }
    }
    public int max3(int x, int y, int z){
        if(x > y){
            return x > z ? x : z;
        } else {
            return y > z ? y : z;
        }
    }
    public int sum2(int x, int y){
        int a = x +y;
        if(a >= 10 && a <= 19){
            return 20;
        } else return a;
    }
    public string day(int x){
        switch (x) {
            case 1:
                return "понедельник";
            case 2:
                return "вторник";
            case 3:
                return "среда";
            case 4:
                return "четверг";
            case 5:
                return "пятница";
            case 6:
                return "суббота";
            case 7:
                return "воскресенье";
            default:
                return "это не день недели";
        }
    }
    public String listNums (int x){
        string a = "";
        for(int i = 0; i <= x; i++){
            a += Convert.ToString(i);
            a += ' ';
        }
        return a;
    }
    public String chet (int x){
        string a = "";
        for(int i = 0; i <= x; i+=2){
            a += Convert.ToString(i);
            a += ' ';
        }
        return a;
    }
    public int numLen (long x){
        int count = 0;
        while(x != 0){
            x= x / 10;
            count++;
        }
        return count;
    }
    public void square (int x){
        for(int i = 0; i < x; i++){
            for(int j = 0;j < x; j++ ){
                Console.Write("*");
            }
            Console.Write("\n");
        }
    }
    public void rightTriangle (int x){
         for (int i = 1; i <= x; i++) {
            for (int j = 1; j <= x - i; j++) {
                Console.Write(" ");
            }
            for (int k = 1; k <= i; k++) {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
    public int findFirst (int[] arr, int x){
        for(int i = 0; i < arr.Length; i++){
            if(arr[i] == x){
                return i;
            }
        }
        return -1;
    }
    public int maxAbs (int[] arr){
        int x = -999999;
        for(int i = 0; i < arr.Length; i++){
            if(arr[i] < 0){
                arr[i] = -arr[i];
            }
            if(arr[i] > x)
            x = arr[i];
        }
        return x;
    }
    public int[] add (int[] arr, int[] ins, int pos){
        int one = arr.Length;
        int two = ins.Length;
        int[] result = new int[one + two];
        
        for (int i = 0; i < pos; i++) {
            result[i] = arr[i];
        }
        for (int i = 0; i < two; i++) {
            result[pos + i] = ins[i];
        }
        for (int i = pos; i < one; i++) {
            result[two + i] = arr[i];
        }
        return result;
    }
    public int[] reverseBack (int[] arr){
        int[] rev = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            rev[i] = arr[arr.Length - 1 - i];
        }
        return rev;
    }

     public int[] findAll (int[] arr, int x){
        int count = 0;
        foreach (int value in arr) {
            if (value == x) {
                count++;
            }
        }
        int[] indices = new int[count];
    
        int index = 0;
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == x) {
                indices[index] = i;
                index++;
            }
        }
    return indices;
    }
}
