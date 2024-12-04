using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Linq;
using NPOI.SS.Formula.Functions;
class Admission{
    private static List<Admission> instance = new List<Admission>();
    private int _id;
    public int Id{
        get{
            return _id;
        }
        set{
            _id = value;
        }
    }
    private int? _idofvalues;
    public int? Idofvalues{
        get{
            return _idofvalues;
        }
        set{
            _idofvalues = value;
        }
    }
    private int? _idofcourse;
    public int? Idofcourse{
        get{
            return _idofcourse;
        }
        set{
            _idofcourse = value;
        }
    }
    
    private string _data;
    public string Data{
        get{
            return _data;
        }
        set{
            _data = value;
        }
    }
    private double _sum;
    public double Sum{
        get{
            return _sum;
        }
        set{
            _sum = value;
        }
    }
    public Admission(string input){
        IWorkbook workbook;
        using(FileStream file = new FileStream(input, FileMode.Open, FileAccess.Read)){
            workbook = new HSSFWorkbook(file);
            ISheet sheet = workbook.GetSheetAt(2);
            int rows = sheet.PhysicalNumberOfRows;
            for(int i = 1; i < rows; i++){
                IRow current = sheet.GetRow(i); // строка
                List<string> mas = new List<string>();
                for(int col = 0; col < current.PhysicalNumberOfCells; col++){
                    string a = current.GetCell(col)?.ToString();
                    mas.Add(a);
                }
                int id = Convert.ToInt32(mas[0]);
                int idofcourse = Convert.ToInt32(mas[2]);
                int idofvalues = Convert.ToInt32(mas[1]);
                string data = mas[3];
                double sum = Convert.ToDouble(mas[4]);
                Admission admission = new Admission(id, idofvalues, idofcourse, data, sum);
                instance.Add(admission);
            }
        }
    }

    private Admission(int id, int idofvalues, int idofcourse, string data, double sum){
        _id = id;
        _idofcourse = idofcourse;
        _idofvalues = idofvalues;
        _data = data;
        _sum = sum;
    }
    //задание 5
    public Admission(int idofvalues, int idofcourse, string data, double sum){
        if(Values.checkid(idofvalues) && Courses.checkid(idofcourse)){
            if(DateTime.TryParseExact(data, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd)){
                Admission admission = new Admission(GetMaxId()+1, idofvalues, idofcourse, birthd.ToString("dd.MM.yyyy"), sum);
                instance.Add(admission);
            } else {Console.WriteLine("Неверная дата");}
        } else {
            Console.WriteLine("невозможно добавить");
        }
    }
    //задание 3
    public static void RemoveByID(int id)
    {
        List<Admission> newinstance = (from Admission in instance
                                      where  Admission.Id != id
                                      select Admission).ToList();
        instance = newinstance;
    }
    //задание 4
    public static void Update(string[] inp){
        int id = Convert.ToInt32(inp[0]);
        int idofvalues = Convert.ToInt32(inp[1]);
        int idofcourse = Convert.ToInt32(inp[2]);
        double sum = Convert.ToDouble(inp[4]);
        Admission valuesToUp = (from Admission in instance
                                where Admission.Id == id
                                select Admission).FirstOrDefault();
        if(valuesToUp != null){
            if(Values.checkid(idofvalues) && Courses.checkid(idofcourse) && DateTime.TryParseExact(inp[3], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd)){
                valuesToUp.Idofvalues = idofvalues;
                valuesToUp.Idofcourse = idofcourse;
                valuesToUp.Data = birthd.ToString("dd.MM.yyyy");
                valuesToUp.Sum = sum;
            } else Console.WriteLine("записи для редактирования нет");
        } else Console.WriteLine("внешние ключи отсутствуют или дата неверная");
    }
    //задание 6.2 - узнаем код валюты
    public static string TakeCourse(int id){
        Admission temp = (from Admission in instance
                          where Admission.Id != id
                          select Admission).FirstOrDefault();
        string result = Courses.GetCode(temp.Idofcourse);
        return result;
    }
    //задание 6.3 - получаем список id
    public static void getfio(int? idofcourse){
        List<int?> check = (from Admission in instance
                           where Admission.Idofcourse == idofcourse
                           select Admission.Idofvalues).ToList();
        Values.course(check);        
    }
    //задание 6.4 - получаем id с максимальным числом за определенную дату
    public static void getidforvalues(int? idofcourse, string data){
        int? check = (from Admission in instance
                           where Admission.Data == data 
                           orderby Admission.Sum descending
                           select Admission.Idofvalues).FirstOrDefault();
        Values.coursetwo(check);        
    }

    //вспомогалки
    public static void IdValuesRemove(int id){
        var admissions = from Admission in instance
                    where Admission.Idofvalues == id
                    select Admission;
        foreach(var adm in admissions){
            adm.Idofvalues = null;
        }
    }
    public static void IdCoursesRemove(int id){
        var admissions = from Admission in instance
                         where Admission.Idofcourse == id
                         select Admission;
        foreach(var adm in admissions){
            adm.Idofcourse = null;
        }
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
        return $"{_id}, {_idofvalues}, {_idofcourse}, {_data}, {_sum}";
    }
}