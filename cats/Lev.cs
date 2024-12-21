class lev : IMeowable{
    private string _name;
    public string Name{
        get{
            return _name;
        }
        set{
            _name = value;
        }
    }
    public lev(string name){
        this._name = name;
    }
    public void Meow(){
        Console.WriteLine($"{Name}: муау");
    }
}