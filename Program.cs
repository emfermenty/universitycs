using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Linq;

class Program{
    public static event Action<string> logs;
    public static void Main(){
        int i;
        Console.WriteLine("Введите true если хотите создать новый файл для логов, иначе false");
        string aww = Console.ReadLine();
        bool choice = bool.Parse(aww);
        string logfile = "log.txt";
        if(choice){
            File.Create(logfile).Close();
        }
        logs += (message) => File.AppendAllText(logfile, $"{DateTime.Now} : {message} \n");

        while(true){
            Console.WriteLine("введите что хотете сделать:\n 1. Считать из эксельки \n 2. Вывод базы \n 3. Удаление элемента(id) \n 4. Корректирование элементов \n 5. Добавление элементов \n 6. Выполнение запросов");
            i = int.Parse(Console.ReadLine());
        switch(i){
            case 1:
                string input = "LR5-var13.xls";
                IWorkbook workbook;
                Values values = new Values(input);
                Courses courses = new Courses(input);
                Admission admission = new Admission(input);
                logs?.Invoke("Успешно считали excel file");
                Console.WriteLine("Успех");
                break;
            case 2:
                Console.WriteLine("Введите название таблицы\n 1 - values.\n 2 - courses.\n 3 - admission: ");
                int ww = int.Parse(Console.ReadLine());
                    switch(ww){
                        case 1:
                            Values.PrintInstances();
                            logs?.Invoke("Вывели данные из таблицы Values");
                        break;
                        case 2:
                            Courses.PrintInstances();
                            logs?.Invoke("Вывели данные из таблицы Courses");
                        break;
                        case 3:
                            Admission.PrintInstances();
                            logs?.Invoke("Вывели данные из таблицы Admission");
                        break;
                    }
            break;
            case 3:
                Console.WriteLine("Введите название таблицы\n 1 - values.\n 2 - courses.\n 3 - admission: ");
                int remove = int.Parse(Console.ReadLine());
                int rem;
                switch(remove){
                    case 1:
                    Console.WriteLine("введите id для удаления: ");
                    rem = int.Parse(Console.ReadLine());
                    Values.RemoveByID(rem);
                    logs?.Invoke($"Удалили элемент с индексом {rem.ToString()} из таблицы Values");
                    break;
                    case 2:
                    Console.WriteLine("введите id для удаления: ");
                    rem = int.Parse(Console.ReadLine());
                    Courses.RemoveByID(rem);
                    logs?.Invoke($"Удалили элемент с индексом {rem.ToString()} из таблицы Courses");
                    break;
                    case 3:
                    Console.WriteLine("введите id для удаления: ");
                    rem = int.Parse(Console.ReadLine());
                    Admission.RemoveByID(rem);
                    logs?.Invoke($"Удалили элемент с индексом {rem.ToString()} из таблицы Admission");
                    break;
                }
            break;
            case 4:
                Console.WriteLine("Введите название таблицы\n 1 - values.\n 2 - courses.\n 3 - admission: ");
                int update = int.Parse(Console.ReadLine());
                switch(update){
                    case 1:
                    Console.Write("введите редактированные данные в формате <id> <Фамилия И. О.> <дата>: ");
                    string[] inpV = Console.ReadLine().Split(' ');
                    Values.Update(inpV);
                    logs?.Invoke($"Обновили данные таблицы в таблице по индексу {inpV[0]} Values");
                    break;
                    case 2:
                    Console.Write("введите редактированные данные в формате <id> <code> <Курс> <имя>: ");
                    string[] inpC = Console.ReadLine().Split(' ');
                    Courses.Update(inpC);
                    logs?.Invoke($"Обновили данные таблицы в таблице по индексу {inpC[1]} Values");
                    break;
                    case 3:
                    Console.Write("введите редактированные данные в формате <id> <idсчета> <idкурса> <дата> <сумма>: ");
                    string[] inpA = Console.ReadLine().Split(' ');
                    Admission.Update(inpA);
                    logs?.Invoke($"Обновили данные таблицы в таблице по индексу {inpA[0]} Values");
                    break;
                }

            break;
            case 5:
                Console.WriteLine("Введите название таблицы\n 1 - values.\n 2 - courses.\n 3 - admission: ");
                int go = int.Parse(Console.ReadLine());
                switch(go){
                    case 1:
                    Console.WriteLine("Введите входные данные в формате <Фамилия И.О.>, <дата>");
                    string[] value = Console.ReadLine().Split(", ");
                    if(value.Length == 2){
                    Values val = new Values(value[0], value[1]);}
                    else {Console.WriteLine("неверные данные");}
                    logs?.Invoke($"Обновили данные таблицы в таблицу Values");
                    break;
                    
                    case 2:
                    Console.WriteLine("Введите входные данные в формате <Код валюты>, <число>, <полное название>");
                    string[] course = Console.ReadLine().Split(", ");
                    if(course.Length == 3){
                    double digit = double.Parse(course[1]);
                    Courses cour = new Courses(course[0], digit, course[2]);}
                    else Console.WriteLine("неверные данные");
                    logs?.Invoke($"Обновили данные таблицы в таблицу Сourses");
                    break;
                    case 3:
                    Console.WriteLine("Введите входные данные в формате <id счёта>, <id валюты>, <дата>, <сумма>");
                    string[] admiss = Console.ReadLine().Split(", ");
                    if(admiss.Length == 4){
                        Admission admission1 = new Admission(int.Parse(admiss[0]), int.Parse(admiss[1]), admiss[2], double.Parse(admiss[3]));
                    }
                    logs?.Invoke($"Обновили данные таблицы в таблицу Admission");
                    break;
                }
            break;
            case 6:
            Console.WriteLine("Введите номер запроса: \n 1. Вывод даты по ФИО \n 2. Узнать код валюты по коду поступления \n 3. Вывод всех пользователей, которые работали с валютой \n 4. Вывод пользователя, который с определенной валютой за определенную дату сделал максимальную сделку");
                int zap = int.Parse(Console.ReadLine());
                switch(zap){
                    // вывод даты открытия вклада по ФИО
                case 1: 
                    Console.WriteLine("Введите <ФИО>");
                    string fio = Console.ReadLine();
                    Console.WriteLine(Values.DateOfValue(fio));
                    logs?.Invoke($"Выполнен запрос - вывод даты открытия вклада, зная фио");
                break;
                    //зная код поступления узнаем код валюты
                case 2:
                    Console.WriteLine("Введите <id поступления>");
                    int idadm = int.Parse(Console.ReadLine());
                    Console.WriteLine(Admission.TakeCourse(idadm));
                    logs?.Invoke($"Выполнен запрос - зная код поступления, узнаем код валюты");
                break;
                    //вывод всей информации о держателях определенной валюты
                case 3:
                    Console.WriteLine("Введите <Код валюты>");
                    string code = Console.ReadLine();
                    Courses.getId(code);
                    logs?.Invoke($"Выполнен запрос - вывод всех держателей, кто пользовался валютой");
                break;
                    //из примера, только валюты тоже запрашиваем
                case 4:
                    Console.WriteLine("Введите <Код валюты> <дату поступления>");
                    string[] qu = Console.ReadLine().Split(" ");
                    if(qu.Length == 2 && DateTime.TryParseExact(qu[1], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthd)){
                        Courses.getIdtwo(qu[0], birthd.ToString("dd.MM.yyyy"));
                    } else {
                        Console.WriteLine("неверные входные данные");
                    }
                    logs?.Invoke($"Выполнен запрос - вывод человека, который за определенную дату с определенной валютой сделал самую большую сделку");
                break;
                }
            break;
            }
        }
    }
}