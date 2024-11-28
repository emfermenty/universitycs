using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


class Program{
    //public delegate void ThreadStart();
    public static void Main(){
        //задание 1
        Program.first<object>();
        // задание 2
        Console.WriteLine("Задание 2");
        Program.two<object>();
        // задание 3
        Program.third();
        // задание 4
        Program.four<object>();
        // задание 5
        List<Person> people = new List<Person>();
        Program.TouchXML(people);
        Program.fifth();
        }
    
        
    //задание 1
    public static void first<T>(){
        List<T> L1 = new List<T>();
        Console.WriteLine("Ввод для L1, введите -1 чтобы остановиться");
        string n = "";
        try{
        while(true){
            n = Console.ReadLine();
            if(n == "-1") break;
            T i = (T)Convert.ChangeType(n,typeof(T));
            L1.Add(i);
        } } catch{
            Console.WriteLine("Неверные данные");
        }
        List<T> L2 = new List<T>();
        Console.WriteLine("Ввод для L2, введите -1 чтобы остановиться");
        n = "";
        try{
        while(true){
            n = Console.ReadLine();
            if(n == "-1") break;
            T i = (T)Convert.ChangeType(n,typeof(T));
            L2.Add(i);
        }}catch{
            Console.WriteLine("Неверные данные");
        }
        
        List<T> L3 = uniqu(L1, L2);
        foreach(T i in L3){
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    private static List<T> uniqu<T> (List<T> L1, List<T> L2){
        List<T> L3 = new List<T>();
        foreach(T i in L1){
            if (!L2.Contains(i)){
                L3.Add(i);
            }
        }
        foreach(T i in L2){
            if(!L1.Contains(i)){
                L3.Add(i);
            }
        }
        return L3;
    }
    //задание 2
        public static void two<T>() {
        LinkedList<T> d = new LinkedList<T>();
        string n = "";
        int max = 0;
        int min = 99999;
        int count = 0;
        while(true){
            n = Console.ReadLine();
            if(n == "-1"){
                break;
            }
            if(int.TryParse(n, out int number)){
                count++;
            }
            T i = (T)Convert.ChangeType(n,typeof(T));
            d.AddLast(i);
        }
        if(count < 2){
            throw new Exception("Мало чисел");
        }
        int num = 0;
        
        LinkedListNode<T> node = d.First;
        tworeshenie(ref node);
        Console.WriteLine("Ответ на второе: ");
        foreach(T i in d){
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    private static void tworeshenie<T>(ref LinkedListNode<T> d) {
        LinkedListNode<T> node = d;
        LinkedListNode<T> max = d;
        LinkedListNode<T> min = d;
        int imax = 0;
        int jmin = 0;
        int index = 1;
        int fmin = 9999;
        int fmax = -9999;
        LinkedListNode<T> temp = d;
        
        while (node != null)
        {
        if (int.TryParse(node.Value.ToString(), out int num))
        {
            if (num < fmin)
            {
                fmin = num;
                min = node;
                jmin = index;
            }
            if (num > fmax) 
            {
                fmax = num;
                max = node;
                imax = index;
            }
        }
        index++;
        node = node.Next;
    }
        if(imax > jmin){
            LinkedListNode<T> p = min.Next;
            while(p != null && p != max){
                LinkedListNode<T> nextNode = p.Next;
                d.List.Remove(p);                        
                p = nextNode;
            }
        } else if(imax < jmin){
            LinkedListNode<T> q = min.Previous; 
            while(q != null && q != max){
                LinkedListNode<T> prevNode = q.Previous;
                d.List.Remove(q);                        
                q = prevNode;
            }
        } else {
            return;
        }
    }
    //Задание 3
    public static void third(){
        List<HashSet<string>> third = new List<HashSet<string>>{
            new HashSet<string>{"Шоу 1", "Шоу 2", "Шоу 3", "Шоу 6"},
            new HashSet<string>{"Шоу 2", "Шоу 4", "Шоу 3"},
            new HashSet<string>{"Шоу 3","Шоу 2","Шоу 1"},
            new HashSet<string>{"Шоу 4","Шоу 2","Шоу 6"} 
        };
        HashSet<string> allliked = new HashSet<string>(third[0]);   
        HashSet<string> someliked = new HashSet<string>();
        HashSet<string> noneliked = new HashSet<string>{"Шоу 1", "Шоу 2", "Шоу 3", "Шоу 4", "Шоу 5", "Шоу 6"};
        foreach(HashSet<string> i in third){
            allliked.IntersectWith(i);
        }
        //Console.WriteLine();
        foreach(string i in allliked){
            Console.Write("Шоу, которые всем нравятся: " + i + " ");
        }
        Console.WriteLine();
        foreach(HashSet<string> i in third){
            foreach(string j in i){
                someliked.Add(j);
            }
        }
        someliked.RemoveWhere(item => allliked.Contains(item));

        Console.Write("Шоу, которые нравятся некоторым: ");
        foreach(string i in someliked){
            Console.Write(i + " ");
        }
        Console.WriteLine();
        foreach (HashSet<string> i in third){
            foreach(string j in i){
                if(noneliked.Contains(j)){
                    noneliked.Remove(j);
                }
            }
        }
        Console.Write("Шоу, которые никому не нравятся: ");
        foreach(string i in noneliked){
            Console.Write(i);
        }
        Console.WriteLine();
    }
    //Задание 4
    public static void four<T>(){
        string input = "input4.txt";
        //string file;
        HashSet<T> unique = new HashSet<T>();
            using (StreamReader filek = new StreamReader(input)){
            string file;
            while ((file = filek.ReadLine()) != null)
            {
                string[] split = file.Split(" ");
                for (int j = 0; j < split.Length; j++)
                {
                    string k = split[j];
                    int n;
                    bool isnum = int.TryParse(k, out n);
                    if (isnum)
                    {
                        unique.Add((T)Convert.ChangeType(n, typeof(T))); 
                    }
                }
            }
        }
        Console.WriteLine("Четвертое");
        foreach (var i in unique)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    //задание 5
    public static void TouchXML(List<Person> peoples)
    {
        Console.WriteLine("Вводим людей) <фамилия><имя><дата рождения> чтобы остановиться - '-1'");
        try{
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "-1") break;

            string[] par = input.Split(' ');
            if (par.Length == 3 && DateTime.TryParseExact(par[2], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd))
            {
                Person peopl = new Person(par[0], par[1], birthd.ToString("dd.MM.yyyy"));
                peoples.Add(peopl);
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }}catch{
            Console.WriteLine("Неверные данные");
        }

        Console.WriteLine("сериализуем");
        using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            xmlSerializer.Serialize(fs, peoples);
        }
    }
    public static void fifth(){
        List<Person> people = new List<Person>();
        using(FileStream fs = new FileStream("people.xml", FileMode.Open)){
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            people = (List<Person>)xmlSerializer.Deserialize(fs);
        }
        if(people.Count > 0){
        Person older = people[0];
        string birth = older.Birth;
        int count = 0;
        foreach(var i in people){
            if(birth == i.Birth){
                count++;
            } else{
                string[] one = birth.Split('.');
                string[] two = i.Birth.Split('.');
                for(int j = one.Length-1; j > 0; j--){
                    if(Convert.ToInt32(one[j]) > Convert.ToInt32(two[j])){
                        older = i;
                        birth = i.Birth;
                        count = 0;
                        count = 1;
                        break;
                    }
                }
            }
        }
        if(count > 1){
            Console.WriteLine(count);
        } else {
            Console.WriteLine(older.ToString());
        }
        } 
    }
}
