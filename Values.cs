using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Linq;
using NPOI.SS.Formula.Functions;

class Values {
    private static List<Values> instance = new List<Values>();
    private int _id;
    public int Id{
        get{
            return _id;
        }
        set{
            _id = value;       
        }
    }
    
    private string _name;
    public string Name{
        get{
            return _name;
        }
        set{
            _name = value;
        }
    }
    private string _date;
    public string Date{
        get{
            return _date;
        }
        set{
            _date = value;
        }
    }
    private Values(int id, string name, string date){
        _id = id;
        _name = name;
        _date = date;
    }
    public Values(string input){
        IWorkbook workbook;
        using(FileStream file = new FileStream(input, FileMode.Open, FileAccess.Read)){
            workbook = new HSSFWorkbook(file);
            ISheet sheet = workbook.GetSheetAt(0);
            int rows = sheet.PhysicalNumberOfRows;
            for(int i = 1; i < rows; i++){
                IRow current = sheet.GetRow(i); // строка
                List<string> mas = new List<string>();
                for(int col = 0; col < current.PhysicalNumberOfCells; col++){
                    string a = current.GetCell(col)?.ToString();
                    mas.Add(a);
                }
                int id = Convert.ToInt32(mas[0]);
                string name = mas[1];
                string data = mas[2];
                Values values = new Values(id, name, data);
                instance.Add(values);
            }
        }
    }
    //задание 5
    public Values(string name, string date){
        Console.WriteLine(date);
        if(DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd)){
            Values values = new Values(GetMaxId()+1, name, birthd.ToString("dd.MM.yyyy"));
            instance.Add(values);
        } else {
            Console.WriteLine("неверные данные");
        }
    }
    //задание 3
    public static void RemoveByID(int id)
    {
        //instance = instance.Where(t => t.Id != id).ToList();
        instance = (from value in instance
                    where value.Id != id
                    select value).ToList();
        Admission.IdValuesRemove(id);
    }
    //задание 4
    public static void Update(string[] inp){ 
        string newname = String.Concat(inp[1], " ", inp[2], " ", inp[3]);
        int id = Convert.ToInt32(inp[0]);
        Values valuestoup = instance.Find(t => t.Id == id);
        if(valuestoup != null){
            if(DateTime.TryParseExact(inp[4], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd)){
                valuestoup.Name = newname;
                valuestoup.Date = birthd.ToString("dd.MM.yyyy");
            } else Console.WriteLine("неверная дата");
        } else Console.WriteLine("Такого id не существует");
    }
    //задание 6 - запрос к одной таблице вывод даты открытия вклада зная фио
    public static string DateOfValue(string name){
        Values person = (from Values in instance
                         where Values.Name == name
                         select Values).FirstOrDefault();
        //instance.FirstOrDefault(t => t.Name == name);
        if(person == null) return "null";
        else return person.Date;
    }
    //Задание 6.3- вывод держателей валюты
    public static void course(List<int?> codes){
        List<Values> yee = (from value in instance
                                where codes.Contains(value.Id)
                                select value).ToList();
        foreach(var i in yee){
            Console.WriteLine(i.ToString());
        }
    }
    //6.3 поиск пользователя
    public static void coursetwo(int? pole){
        Values yee = (from value in instance
                    where value.Id == (int)pole
                    select value).FirstOrDefault();
            Console.WriteLine(yee.ToString());
    }

    //вспомогалки
    public static bool checkid(int id){
        Values values = instance.Find(c => c.Id == id);
        if(values != null) return true;
        else return false;
    }
    private static int GetMaxId(){
        return instance.Max(v => v.Id); 
    }
    public static void PrintInstances()
    {
        Console.WriteLine("Существующие экземпляры values:");
        foreach (var i in instance)
        {
            Console.WriteLine(i.ToString());
        }
    }
    public override string ToString()
    {
        return $"{_id}, {_name}, {_date}";
    }
}