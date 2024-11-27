using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

[Serializable]
public struct Toy{
    string Name;
    int Price;
    int Minage;
    int Maxage;
    public Toy(string name, int price, int minage, int maxage){
        Name = name;
        Price = price;
        Minage = minage;
        Maxage = maxage;
    }
    public string GetName() 
    {
        return Name;
    }

    public int GetPrice() 
    {
        return Price;
    }
    
    public int GetMinage() 
    {
        return Minage;
    }
    
    public int GetMaxage() 
    {
        return Maxage;
    }
}


public class Files
{
    static Random R = new Random();

    public Files(){

    }
//задание 4
    public static void First()
    {
        string input = "input.bin";
        string output = "output.bin";
        List<int> b = new List<int>();
        List<int> c = new List<int>();
        using (FileStream f = new FileStream(input, FileMode.OpenOrCreate)){
        BinaryWriter file = new BinaryWriter(f);
        int n = R.Next(5, 20);
        Console.WriteLine("Входной файл: ");
        for (int i = 0; i < n; i++)
        {
            int a = R.Next(0, 10);
            Console.Write(a + "\t");
            file.Write(a);
        }
        Console.WriteLine();
        }
        using (FileStream f = new FileStream(input, FileMode.Open)){
        BinaryReader readInput = new BinaryReader(f);
        while (readInput.BaseStream.Position < readInput.BaseStream.Length)
        {
            b.Add(readInput.ReadInt32());
        }
        }
        foreach (int bb in b)
        {
            if (!c.Contains(bb))
            {
                c.Add(bb);
            }
        }

        using (FileStream f = new FileStream(output, FileMode.Create)){
        BinaryWriter file = new BinaryWriter(f);
        foreach (int i in c)
        {
            file.Write(i);
        }
        }

        using (FileStream f = new FileStream(output, FileMode.Open)){
        BinaryReader readInput = new BinaryReader(f);
        Console.WriteLine("Выходной файл: ");
        while (readInput.BaseStream.Position < readInput.BaseStream.Length)
        {
            int number = readInput.ReadInt32();
            Console.Write(number + "\t");
        }
        Console.WriteLine();
        }
    }
    //задание 5
    public static void touchtoysfile(){
        List<Toy> toys = new List<Toy>(){
            new Toy("Мяч", 300, 1, 5),
            new Toy("Лего", 1200, 1, 10),
            new Toy("Кукла", 500, 2, 5),
            new Toy("Пазлы", 800, 2, 6),
            
        };
        using(FileStream fs = new FileStream("toys.xml", FileMode.OpenOrCreate)){
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Toy>));
            xmlSerializer.Serialize(fs, toys);
        }
        toys = null;
    }
    public static string maxtoy(){
        List<Toy> toys;
        string fss = "toys.xml";

        int min = 2;
        int max = 3;
        int maxprice = -9999;
        string result = null;
        using(FileStream ffss = new FileStream(fss, FileMode.Open)){
            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            toys = (List<Toy>)serializer.Deserialize(ffss);
        }
        foreach(Toy i in toys){
            if(i.GetMinage() <= min && i.GetMaxage() >= max){
                if(i.GetPrice() > maxprice){
                    result = i.GetName();
                    maxprice = i.GetPrice();
                }
            }
        }
        if(result == null) return "Нет подходящего";
        else return result;
    }
    //заданиие 6
    public static void zap(){
        string input2 = "input6.txt";
        using(FileStream f = new FileStream(input2, FileMode.OpenOrCreate)){
        using (StreamWriter ff = new StreamWriter(f)){
        int a = R.Next(10, 30);
        for(int i = 0; i < a; i++){
            int k = R.Next(10, 1000);
            ff.WriteLine(k);
        }
        }
    }
}
    public static void mission6(){
        string input2 = "input6.txt";
        Console.WriteLine("Задание 6: Введите необходимое значение");
        bool flag = true;
        //int find;
        while(flag){
        try{
        int find = int.Parse(Console.ReadLine());
        int count = 0;
        using (StreamReader f = new StreamReader(input2)){
        string line;
        while((line = f.ReadLine()) != null){
            if(line[line.Length-1]- '0'== find){
                count += Convert.ToInt32(line);
            }
        }
        Console.WriteLine("Заданиие 6: " + count);
        }
        flag = false;
        } catch {
            Console.WriteLine("неверное");
        }
    }
}
    //задание 7
    public static void zapfor7(){
        string input7 = "input7.txt";
        using (FileStream f = new FileStream(input7, FileMode.OpenOrCreate)){
        using(StreamWriter fs = new StreamWriter(f)){
        int lines = R.Next(3, 10);
        int rows = R.Next(3,10);
        for(int i = 0; i < lines; i++){
            for(int j = 0; j < rows; j++){
                int rand = R.Next(1, 100);
                fs.Write(rand);
                if(j < rows -1){
                    fs.Write(" ");
                }
            }
            fs.WriteLine();
        }
        }
        }
    }
    public static void calc7(){
        string input7 = "input7.txt";
        using (StreamReader fs = new StreamReader(input7)){
        string firstline = fs.ReadLine();
        int min = 9999999;
        string[] firstlineel = firstline.Split(" ");
        int one = int.Parse(firstlineel[0]);
        while(!fs.EndOfStream){
            string line = fs.ReadLine();
            string[] num = line.Split(" ");
            foreach(string nubmer in num){
                int curr = int.Parse(nubmer);
                if(curr < min){
                    min = curr;
                }
            }
        }
        Console.WriteLine("Задание 7 \n Первое минус минимальное: " + (one -= min));
        }
    }
    //Задание 8
    public static void zapfor8()
    {
        string inputFilePath = "input8.txt";
        string outputFilePath = "output8.txt";
        char[] punctuation = { '.', ',', '!', '?', ';', ':', '-', '(', ')'};
        using (StreamReader reader = new StreamReader(inputFilePath)){
        using (StreamWriter writer = new StreamWriter(outputFilePath)){
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.IndexOfAny(punctuation) == -1)
                {
                    writer.WriteLine(line); 
                }
            }
        }
    }
    }
}
