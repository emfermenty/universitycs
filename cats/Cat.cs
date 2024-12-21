using System;

class Cat : IMeowable{
    private string _name;
    public string Name{
        get{
            return _name;
        }
        set{
            _name = value;
        }
    }
    public Cat(string name){
        this._name = name;
    }
    public override string ToString()
    {
        return $"Имя: {Name}";
    }
    public void Meow(){
        Console.WriteLine($"{Name}: Мяу!");
    }
    public void Meow(int N){
        Console.Write($"{Name}: ");
        for(int i = N; i > 0; i--){
            if(i != 1)
                Console.Write("мяу-");
            else
                Console.Write("мяу!");
        }
        Console.Write("\n");
    }
}