using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

class Courses{  
    private static List<Courses> instance = new List<Courses>();
    private int _id;
    public int Id{
        get{
            return _id; 
        }
        set{
            _id = value;
        }
    }
    private string _code;
    public string Code{
        get{
            return _code;
        }
        set{
            _code = value;
        }
    }
    private double _course;
    public double Course{
        get{
            return _course;
        }
        set{
            _course = value;
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
    
    public Courses(string input){
        IWorkbook workbook;
        using(FileStream file = new FileStream(input, FileMode.Open, FileAccess.Read)){
            workbook = new HSSFWorkbook(file);
            ISheet sheet = workbook.GetSheetAt(1);
            int rows = sheet.PhysicalNumberOfRows;
            //string[] mas = new string[current.PhysicalNumberOfCells];
            for(int i = 1; i < rows; i++){
                IRow current = sheet.GetRow(i); // строка
                List<string> mas = new List<string>();
                for(int col = 0; col < current.PhysicalNumberOfCells; col++){
                    string a = current.GetCell(col)?.ToString();
                    mas.Add(a);
                }
                int id = Convert.ToInt32(mas[0]);
                string code = mas[1];
                double course = Convert.ToDouble(mas[2]);
                string name = mas[3];
                Courses courses = new Courses(id, code, course, name);
                instance.Add(courses);
            }
        }
    }
    private Courses(int id, string code, double course, string name){
        _id = id;
        _code = code;
        _course = course;
        _name = name;
    }
    //задание 5
    public Courses(string code, double course, string name){
        Courses c = (from Courses in instance
                          where Courses.Code == code
                          select Courses).FirstOrDefault();
        if(c == null){
            Console.WriteLine("код занят");
        }else{
        Courses courses = new Courses(GetMaxId()+1, code, course, name);
        instance.Add(courses);
        }
    }
    //задание 3
    public static void RemoveByID(int id)
    {
        List<Courses> newinstance = (from Courses in instance
                                      where  Courses.Id != id
                                      select Courses).ToList();
        instance = newinstance;
        Admission.IdCoursesRemove(id);
    }
    //задание 4
    public static void Update(string[] inp){
        int id = Convert.ToInt32(inp[0]);
        double course = Convert.ToDouble(inp[2]);
        string name = string.Join(" ", inp[3..]);
        Courses valuesToUp = (from Courses in instance
                              where Courses.Id == id
                              select Courses).FirstOrDefault();
        if(valuesToUp != null){
            bool k = (from Courses in instance 
                      where Courses.Code == inp[1]
                      select Courses).Any();
            if(!k){
                valuesToUp.Code = inp[1];
                valuesToUp.Course = course;
                valuesToUp.Name = name;
            } else Console.WriteLine("код не уникальный");
        } else Console.WriteLine("Такого id не существует");
    }
    //задание 5
    public static bool checkid(int id){
        Courses courses = (from Courses in instance
                            where Courses.Id == id
                            select Courses).FirstOrDefault();
        if(courses != null) return true;
        else return false;
    }
    //задание 6.2 - узнаем код валюты
    public static string GetCode(int? id){
        Courses temp = (from Courses in instance
                        where Courses.Id == id
                        select Courses).FirstOrDefault();
        return temp.Code;
    }

    //задание 6.3 - получаем id валюты
    public static void getId(string code){
        int? id = (from Courses in instance
                   where Courses.Code == code
                   select Courses.Id).FirstOrDefault();
        if(id != null){
            Admission.getfio(id);
        } else {
            Console.WriteLine("код не существует");
        }
    }
    //получаем id валюты
    public static void getIdtwo(string code, string data){
        int? id = (from Courses in instance
                   where Courses.Code == code
                   select Courses.Id).FirstOrDefault();
        if(id != null){
            Admission.getidforvalues(id, data);
        } else {
            Console.WriteLine("код не существует");
        }
    }

    //вспомогалки
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
        return $"{_id}, {_code}, {_course}, {_name}";
    }
}
