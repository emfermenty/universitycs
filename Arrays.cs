using System;

class Array<T>{
    private T[,] arr;
    public T[,] getarr(){
        return arr;
    }
    //3 задание
    public Array(int n, int m){
        this.arr = new T[n,m];
    }
    public Array(int n, int m, char o){
        arr = new T[n, m];
        for (int startRow = n - 1, startCol = 0; startCol < n; )
        {
            int row = startRow;
            int col = startCol;
            while (row < n && col < n)
            {
                Console.Write($"Введите по позиции ({col} {row}) ");
                arr[row, col] = (T)Convert.ChangeType(int.Parse(Console.ReadLine()), typeof(T));
                row++;
                col++;
            }
            if (startRow > 0)
            {
                startRow--; 
            }
            else
            {
                startCol++; 
            }
        }
    }
    public Array(int n){
        arr = new T[n,n]; 
        Random random = new Random();
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if(j == 0){
                    arr[i, j] = (T)Convert.ChangeType(random.Next(1, 10), typeof(T));
                } else
                arr[i, j] = (T)Convert.ChangeType((dynamic)arr[i, j - 1] - random.Next(1, 10), typeof(T));
            }
        }
    }
    public Array(int n, int m, int x){
        arr = new T[n,m];
        //thirdarr(n,m, x);
    int rowStart = 0;
    int rowEnd = n - 1;
    int colStart = 0;
    int colEnd = m - 1;
    //int x = startValue; // Начинаем с заданного значения

    while (rowStart <= rowEnd && colStart <= colEnd)
    {
        // Заполнение первого столбца
        for (int i = rowStart; i <= rowEnd; i++)
        {
            arr[i, colStart] = (T)Convert.ChangeType(x++, typeof(T));
        }
        colStart++;

        // Заполнение последней строки
        for (int i = colStart; i <= colEnd; i++)
        {
            arr[rowEnd, i] = (T)Convert.ChangeType(x++, typeof(T));
        }
        rowEnd--;

        // Заполнение последнего столбца, если еще есть строки
        if (rowStart <= rowEnd)
        {
            for (int row = rowEnd; row >= rowStart; row--)
            {
                arr[row, colEnd] = (T)Convert.ChangeType(x++, typeof(T));
            }
            colEnd--;
        }

        // Заполнение первого ряда, если еще есть столбцы
        if (colStart <= colEnd)
        {
            for (int col = colEnd; col >= colStart; col--)
            {
                arr[rowStart, col] = (T)Convert.ChangeType(x++, typeof(T));
            }
            rowStart++;
        }
    }
}
    //задание 2
    public Array(){
        Console.WriteLine("Введите количество депутатов");
        int k = int.Parse(Console.ReadLine());
        arr = new T[k, 2];
        for(int i = 0; i < k; i ++){
            for(int j = 0; j < 2; j++){
                Console.WriteLine($"Введите значения true или false для депутата {i+1} и выбора {j+1}");
                arr[i, j] = (T)Convert.ChangeType(bool.Parse(Console.ReadLine()), typeof(T));

            }
        }PrintArray();
            task2(arr, k);
    }
    
    //задание 2
    public void task2(T[,] arr, int k){
        int yes = 0;
        int no = 0;
        for(int i = 0; i < k; i++){
            if(arr[i, 0].Equals(arr[i, 1])){
                yes++;
            } else no++;
        } 
        if(yes > no) Console.WriteLine("Больше тех, кто проголосовал однозначно");
        else if(no > yes) Console.WriteLine("Больше тех, кто проголосовал неоднозначно ");
        else Console.WriteLine("Депутатов поровну");
    }
    // задание 3
    // вычитание
    //private void newar()
    //{
    //    arr = new T[n, m];
    //}
    public static Array<T> operator -(Array<T> a, Array<T> b)
    {
        if (a.arr.GetLength(0) != b.arr.GetLength(0) || a.arr.GetLength(1) != b.arr.GetLength(1))
        {
            throw new InvalidOperationException("Matrices must have the same dimensions for subtraction.");
        }
        Array<T> result = new Array<T>(a.arr.GetLength(0), a.arr.GetLength(1));
        for (int i = 0; i < a.arr.GetLength(0); i++)
        {
            for (int j = 0; j < a.arr.GetLength(1); j++)
            {
                dynamic x = a.getarr()[i,j];
                dynamic y = b.getarr()[i,j];
                result.getarr()[i,j] = (T)(x-y);
            }
        }
        return result;
    }
    // сложение
    public static Array<T> operator +(Array<T> a, Array<T> b)
    {
        if (a.arr.GetLength(0) != b.arr.GetLength(0) || a.arr.GetLength(1) != b.arr.GetLength(1))
        {
            throw new InvalidOperationException("длина матриц разнится");
        }
        Array<T> result = new Array<T>(a.arr.GetLength(0), a.arr.GetLength(1));
        for (int i = 0; i < a.arr.GetLength(0); i++)
        {
            for (int j = 0; j < a.arr.GetLength(1); j++)
            {
                dynamic x = a.getarr()[i,j];
                dynamic y = b.getarr()[i,j];
                result.getarr()[i,j] = (T)(x+y);
            }
        }
        return result;
    }
    // умножение
    public static Array<T> operator *(Array<T> a, int scalar)
    {
        Array<T> result = new Array<T>(a.arr.GetLength(0), a.arr.GetLength(1));

        for (int i = 0; i < a.arr.GetLength(0); i++)
        {
            for (int j = 0; j < a.arr.GetLength(1); j++)
            {
                dynamic x = a.getarr()[i, j];
                result.getarr()[i, j] = (T)(x * scalar);
            }
        }

        return result;
    }
    //транспонирование матрицы
    public void Transpose()
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        //int[,] aw = new int[rows, cols];
        T[,] transposed = new T[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = arr[i, j];
            }
        }
        arr = transposed;
        //return transposed;
    }

    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                result += arr[i, j].ToString() + "\t";
            }
            result += "\n";
        }
        return result;
    }
    //вывод массива
    public void PrintArray(){
    int nn = arr.GetLength(0);
    int mm = arr.GetLength(1);
    for (int i = 0; i < nn; i++)
        {
            for (int j = 0; j < mm; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    } 
}
